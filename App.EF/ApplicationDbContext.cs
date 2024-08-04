using App.Core.Helper.Json;
using App.Core.Helper.Validations;
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
using App.Core.Models.UsersModule._01_1_UserTypes;
using App.Core.Models.UsersModule._01_1_UserTypes._02_UserPatientData;
using App.EF.Configurations;
using App.EF.Configurations.Converter;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace App.EF
{
    public class ApplicationDbContext : DbContext
    {
        private readonly ILogger<ApplicationDbContext> _logger;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly string _userAuthorizeToken = "userAuthorizeToken";

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, ILogger<ApplicationDbContext> logger, IHttpContextAccessor httpContextAccessor) : base(options)
        {
            _logger = logger;
            _httpContextAccessor = httpContextAccessor;
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
            GenerateCodes();
            //LogChanges();
            return base.SaveChanges();
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            GenerateCodes();
            //LogChanges();
            return await base.SaveChangesAsync(cancellationToken);
        }

        private void GenerateCodes()
        {
            var entries = ChangeTracker.Entries()
                .Where(e => e.Entity is BaseEntity && e.State == EntityState.Added || e.State == EntityState.Modified).ToList();

            foreach (var entry in entries)
            {
                var entity = (BaseEntity)entry.Entity;
                if ((entry.State == EntityState.Added || entry.State == EntityState.Modified) && !ValidationClass.IsValidString(entity.fullCode))
                    entity.fullCode = GenerateUniqueFullCode();
            }
        }

        private string GenerateUniqueFullCode()
        {
            return "fullname";
        }

        private Guid GetUserToken()
        {
            if (!_httpContextAccessor.HttpContext.Request.Headers.TryGetValue(_userAuthorizeToken, out var userAuthorizeToken) || string.IsNullOrEmpty(userAuthorizeToken))
                return Guid.Empty;

            var userToken = JsonConversion.DeserializeUserAuthorizeToken(userAuthorizeToken).userToken;

            if (userToken == Guid.Empty)
                return Guid.Empty;

            return userToken;
        }

        private void LogChanges()
        {
            var entries = ChangeTracker.Entries()
                                       .Where(e => e.Entity is BaseEntity &&
                                                  (e.State == EntityState.Added ||
                                                   e.State == EntityState.Modified ||
                                                   e.State == EntityState.Deleted));

            foreach (var entityEntry in entries)
            {
                var entity = (BaseEntity)entityEntry.Entity;

                switch (entityEntry.State)
                {
                    case EntityState.Added:
                        entity.createdDate = DateTimeOffset.Now;
                        break;

                    case EntityState.Modified:
                        entity.updatedDate = DateTimeOffset.Now;
                        break;

                    case EntityState.Deleted:
                        entity.isDeleted = true;
                        entity.updatedDate = DateTimeOffset.Now;
                        break;
                }
            }

            var logEntries = entries.Select(CreateLogEntry).ToList();

            // Add the log entries to the LogActions DbSet after enumeration is complete
            LogActions.AddRange(logEntries);
        }

        private LogAction CreateLogEntry(EntityEntry entry)
        {
            var logEntry = new LogAction
            {
                userToken = GetUserToken(),
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

        private string SerializeProperties(PropertyValues values)
        {
            return JsonConvert.SerializeObject(
                values.Properties.ToDictionary(p => p.Name, p => values[p]),
                JsonSettings.IgnoreSelfReferencesAndSpecificProperties);
        }

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

        #endregion DB Tables
    }
}