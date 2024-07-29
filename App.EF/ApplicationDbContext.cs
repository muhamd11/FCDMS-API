using App.Core.Models.ClinicModules.NutritionalImprovementsModules;
using App.Core.Models.ClinicModules.OperationsModules;
using App.Core.Models.SystemBase._01._2_SystemRoleFunctions;
using App.Core.Models.SystemBase.Roles;
using App.Core.Models.Users;
using App.Core.Models.UsersModule._01._1_UserTypes._04_UserDoctor;
using App.Core.Models.UsersModule._01._1_UserTypes.UserEmployee;
using App.Core.Models.UsersModule._01_1_UserTypes;
using App.Core.Models.UsersModule._01_1_UserTypes._02_UserPatientData;
using App.Core.Models.UsersModule.LogActionsModel;
using Microsoft.EntityFrameworkCore;

namespace App.EF
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        #region override Configurations

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
        }

        #region override SaveChanges

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

        #endregion ClinicModules

        #endregion DB Tables
    }
}