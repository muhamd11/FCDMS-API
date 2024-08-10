using App.Core.Interfaces.General;
using App.Core.Models.ClinicModules.MedicalHistoriesModules;
using App.Core.Models.ClinicModules.NutritionalImprovementsModules;
using App.Core.Models.ClinicModules.OperationsModules;
using App.Core.Models.ClinicModules.VisitsModules;
using App.Core.Models.SystemBase._01._2_SystemRoleFunctions;
using App.Core.Models.SystemBase.LogActions;
using App.Core.Models.SystemBase.Roles;
using App.Core.Models.Users;
using App.Core.Models.UsersModule._01._1_UserTypes._04_UserDoctor;
using App.Core.Models.UsersModule._01._1_UserTypes.UserEmployee;
using App.Core.Models.UsersModule._01._2_UserAuthentications.ForgetPasswordModules;
using App.Core.Models.UsersModule._01_1_UserTypes;
using App.Core.Models.UsersModule._01_1_UserTypes._02_UserPatientData;

namespace App.Core

{
    public interface IUnitOfWork : IDisposable
    {
        #region SystemBase

        IBaseRepository<SystemRole> SystemRoles { get; }
        IBaseRepository<SystemRoleFunction> SystemRoleFunctions { get; }
        IBaseRepository<LogAction> LogActions { get; }

        #endregion SystemBase

        #region UsersModule

        IBaseRepository<User> Users { get; }
        IBaseRepository<UserProfile> UserProfiles { get; }
        IBaseRepository<UserPatient> UserPatients { get; }
        IBaseRepository<UserEmployee> UserEmployees { get; }
        IBaseRepository<UserDoctor> UserDoctors { get; }

        #endregion UsersModule

        #region ClinicModules

        IBaseRepository<Operation> Operations { get; }
        IBaseRepository<NutritionalImprovement> NutritionalImprovements { get; }
        IBaseRepository<Visit> Visits { get; }
        IBaseRepository<MedicalHistory> MedicalHistories { get; }

        #endregion ClinicModules

        #region AuthenticationModules

        IBaseRepository<OtpRecord> OtpRecords { get; }

        #endregion AuthenticationModules

        Task<int> CommitAsync();
    }
}