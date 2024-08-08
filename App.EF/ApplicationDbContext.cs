using App.Core.Helper.Json;
using App.Core.Interfaces.GeneralInterfaces;
using App.Core.Models.ClinicModules.MedicalHistoriesModules;
using App.Core.Models.ClinicModules.NutritionalImprovementsModules;
using App.Core.Models.ClinicModules.OperationsModules;
using App.Core.Models.ClinicModules.VisitsModules;
using App.Core.Models.SystemBase._01._2_SystemRoleFunctions;
using App.Core.Models.SystemBase.BaseClass;
using App.Core.Models.SystemBase.LogActions;
using App.Core.Models.SystemBase.Roles;
using App.Core.Models.Users;
using App.Core.Models.UsersModule._01._1_UserTypes._04_UserDoctor;
using App.Core.Models.UsersModule._01._1_UserTypes.UserEmployee;
using App.Core.Models.UsersModule._01._2_UserAuthentications.ForgetPasswordModules;
using App.Core.Models.UsersModule._01_1_UserTypes;
using App.Core.Models.UsersModule._01_1_UserTypes._02_UserPatientData;
using App.EF.Configurations;
using App.EF.Configurations.Converter;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Newtonsoft.Json;

namespace App.EF
{
    public class ApplicationDbContext : DbContext
    {
        private readonly IHeaderRequest _headerRequest;

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, IHeaderRequest headerRequest) : base(options)
        {
            _headerRequest = headerRequest;
        }

        #region override Configurations

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //SeedData
            new DataSeeding().Configure(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
        }

        protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
        {
            configurationBuilder.Properties<decimal>().HavePrecision(30, 18);

            // Date is a DateOnly property and date on database
            configurationBuilder.Properties<decimal>().HaveConversion<DecimalConverter, DecimalComparer>();
        }

        #region override SaveChanges

        public override int SaveChanges()
        {
            LogChanges();
            SetStringEmptyByNull();
            return base.SaveChanges();
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            LogChanges();
            SetStringEmptyByNull();
            return await base.SaveChangesAsync(cancellationToken);
        }

        private void LogChanges()
        {
            var entries = ChangeTracker.Entries()
                                       .Where(e => e.Entity is BaseEntity && (e.State == EntityState.Added || e.State == EntityState.Modified || e.State == EntityState.Deleted));

            foreach (var entityEntry in entries)
            {
                var entity = (BaseEntity)entityEntry.Entity;

                switch (entityEntry.State)
                {
                    case EntityState.Added:
                        entity.createdDate = DateTimeOffset.UtcNow;
                        break;

                    case EntityState.Modified:
                        entity.updatedDate = DateTimeOffset.UtcNow;
                        break;

                    case EntityState.Deleted:
                        entity.isDeleted = true;
                        entity.updatedDate = DateTimeOffset.UtcNow;
                        break;
                }
            }

            // Add the log entries to the LogActions DbSet after enumeration is complete
            var logEntries = entries.Select(CreateLogEntry).ToList();
            LogActions.AddRange(logEntries);
        }

        private LogAction CreateLogEntry(EntityEntry entry)
        {
            var logEntry = new LogAction
            {
                userToken = _headerRequest.GetUserToken(),
                modelName = entry.Entity.GetType().Name,
                actionType = entry.State.ToString(),
                actionDate = DateTime.UtcNow
            };

            switch (entry.State)
            {
                case EntityState.Modified:
                    var databaseValues = entry.GetDatabaseValues();
                    logEntry.oldActionData = SerializeProperties(databaseValues);
                    logEntry.newActionData = SerializeProperties(entry.CurrentValues);
                    break;

                case EntityState.Deleted:
                    logEntry.oldActionData = SerializeProperties(entry.OriginalValues);
                    break;

                case EntityState.Added:
                    logEntry.newActionData = SerializeProperties(entry.CurrentValues);
                    break;
            }

            return logEntry;
        }

        private void SetStringEmptyByNull()
        {
            var values = ChangeTracker.Entries().Where(e => e.State == EntityState.Added || e.State == EntityState.Modified)
                                                .Select(x => x.CurrentValues).ToList();

            foreach (var value in values)
            {
                var properties = value.Properties.Where(p => p.ClrType == typeof(string) && string.IsNullOrWhiteSpace(value[p] as string)).ToList();
                foreach (var property in properties)
                    value[property] = null;
            }
        }

        private string SerializeProperties(PropertyValues values)
            => JsonConvert.SerializeObject(values.Properties.ToDictionary(p => p.Name, p => values[p]), JsonSettings.IgnoreSelfReferencesAndSpecificProperties);

        #endregion override SaveChanges

        #endregion override Configurations

        #region DB Tables

        #region SystemBase

        public DbSet<SystemRole> SystemRoles { get; set; }
        public DbSet<SystemRoleFunction> SystemRoleFunctions { get; set; }
        public DbSet<LogAction> LogActions { get; set; }

        #endregion SystemBase

        #region UsersModule

        public DbSet<User> Users { get; set; }
        public DbSet<UserProfile> UserProfiles { get; set; }
        public DbSet<UserPatient> UserPatients { get; set; }
        public DbSet<UserEmployee> UserEmployees { get; set; }
        public DbSet<UserDoctor> UserDoctors { get; set; }

        #endregion UsersModule

        #region ClinicModules

        public DbSet<Operation> Operations { get; set; }
        public DbSet<NutritionalImprovement> NutritionalImprovements { get; set; }
        public DbSet<Visit> Visits { get; set; }
        public DbSet<MedicalHistory> MedicalHistories { get; set; }

        #endregion ClinicModules

        #region AuthenticationModule

        public DbSet<OtpRecord> ForgetPasswords { get; set; }

        #endregion AuthenticationModule

        #endregion DB Tables
    }
}