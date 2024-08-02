using App.Core.Helper.Validations;
using App.Core.Models.AdditionalModules.FullCodeSequence;
using App.Core.Models.ClinicModules.MedicalHistoriesModules;
using App.Core.Models.ClinicModules.NutritionalImprovementsModules;
using App.Core.Models.ClinicModules.OperationsModules;
using App.Core.Models.ClinicModules.VisitsModules;
using App.Core.Models.SystemBase._01._2_SystemRoleFunctions;
using App.Core.Models.SystemBase.BaseClass;
using App.Core.Models.SystemBase.Roles;
using App.Core.Models.Users;
using App.Core.Models.UsersModule._01._1_UserTypes._04_UserDoctor;
using App.Core.Models.UsersModule._01._1_UserTypes.UserEmployee;
using App.Core.Models.UsersModule._01_1_UserTypes;
using App.Core.Models.UsersModule._01_1_UserTypes._02_UserPatientData;
using App.Core.Models.UsersModule.LogActionsModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace App.EF
{
    public class ApplicationDbContext : DbContext
    {
        private readonly ILogger<ApplicationDbContext> _logger;



        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, ILogger<ApplicationDbContext> logger) : base(options)
        {
            _logger = logger;
        }

        #region override Configurations

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);

            // Seed initial data
            modelBuilder.Entity<FullCodeSequence>().HasData(
                new FullCodeSequence
                {
                    fullCodeSequenceToken = Guid.NewGuid(),
                    nextValue = 99 // Set initial value here
                }
            );

        }

        #region override SaveChanges





        public override int SaveChanges()
        {
            GenerateCodes();
            return base.SaveChanges();
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            GenerateCodes();
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
            try
            {
                var sequence = FullCodeSequences.AsQueryable().First();
                int nextValue = sequence.nextValue;
                sequence.nextValue += 1;
                FullCodeSequences.Update(sequence);
                return nextValue.ToString();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw; // Re-throw the exception after logging
            }
        }




        //public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        //{
        //    LogChanges();
        //    return await base.SaveChangesAsync(cancellationToken);
        //}

        //private void LogChanges()
        //{
        //    var entries = ChangeTracker.Entries().Where(e => e.Entity is BaseEntity && (e.State == EntityState.Added || e.State == EntityState.Modified
        //                                                                                                             || e.State == EntityState.Deleted));

        //    foreach (var entityEntry in entries)
        //    {
        //        var entity = (BaseEntity)entityEntry.Entity;

        //        if (entityEntry.State == EntityState.Added)
        //        {
        //            entity.createdDate = DateTimeOffset.Now;
        //        }

        //        if (entityEntry.State == EntityState.Modified)
        //        {
        //            entity.updatedDate = DateTimeOffset.Now;
        //        }

        //        if (entityEntry.State == EntityState.Deleted)
        //        {
        //            entity.isDeleted = true;
        //            entity.updatedDate = DateTimeOffset.Now;
        //        }
        //    }

        //    var logEntries = ChangeTracker.Entries()
        //                                  .Select(CreateLogEntry)
        //                                  .ToList(); // Collect log entries in a separate list

        //    // Add the log entries to the LogActions DbSet after enumeration is complete
        //    LogActions.AddRange(logEntries);
        //}

        //private LogAction CreateLogEntry(EntityEntry entry)
        //{
        //    var logEntry = new LogAction
        //    {
        //        userToken = Guid.NewGuid(), //TODO: Replace with actual user identifier
        //        modelName = entry.Entity.GetType().Name,
        //        actionType = entry.State.ToString(),
        //        actionDate = DateTime.UtcNow
        //    };

        //    if (entry.State == EntityState.Modified)
        //    {
        //        var databaseValues = entry.GetDatabaseValues();
        //        logEntry.oldData = JsonConvert.SerializeObject(
        //            databaseValues.Properties.ToDictionary(p => p.Name, p => databaseValues[p]),
        //            JsonSettings.IgnoreSelfReferencesAndSpecificProperties);

        //        logEntry.newData = JsonConvert.SerializeObject(
        //            entry.CurrentValues.Properties.ToDictionary(p => p.Name, p => entry.CurrentValues[p]),
        //            JsonSettings.IgnoreSelfReferencesAndSpecificProperties);
        //    }
        //    else if (entry.State == EntityState.Deleted)
        //    {
        //        logEntry.oldData = JsonConvert.SerializeObject(
        //            entry.OriginalValues.Properties.ToDictionary(p => p.Name, p => entry.OriginalValues[p]),
        //            JsonSettings.IgnoreSelfReferencesAndSpecificProperties);
        //    }
        //    else if (entry.State == EntityState.Added)
        //    {
        //        logEntry.newData = JsonConvert.SerializeObject(
        //            entry.CurrentValues.Properties.ToDictionary(p => p.Name, p => entry.CurrentValues[p]),
        //            JsonSettings.IgnoreSelfReferencesAndSpecificProperties);
        //    }

        //    return logEntry;
        //}

        #endregion override SaveChanges

        #endregion override Configurations

        #region DB Tables

        #region AdditionalModule

        public DbSet<FullCodeSequence> FullCodeSequences { get; set; }


        #endregion

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