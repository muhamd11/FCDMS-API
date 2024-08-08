using App.Core;
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
using App.EF.Repositories;

namespace App.EF
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;

        #region SystemBase

        public IBaseRepository<SystemRole> SystemRoles { get; private set; }
        public IBaseRepository<SystemRoleFunction> SystemRoleFunctions { get; private set; }
        public IBaseRepository<LogAction> LogActions { get; private set; }

        #endregion SystemBase

        #region UsersModule

        public IBaseRepository<User> Users { get; private set; }
        public IBaseRepository<UserProfile> UserProfiles { get; private set; }
        public IBaseRepository<UserPatient> UserPatients { get; private set; }
        public IBaseRepository<UserEmployee> UserEmployees { get; private set; }
        public IBaseRepository<UserDoctor> UserDoctors { get; private set; }

        #endregion UsersModule

        #region ClinicModules

        public IBaseRepository<Operation> Operations { get; private set; }
        public IBaseRepository<NutritionalImprovement> NutritionalImprovements { get; private set; }
        public IBaseRepository<Visit> Visits { get; private set; }
        public IBaseRepository<MedicalHistory> MedicalHistories { get; private set; }

        #endregion ClinicModules

        #region AuthenticationModules 

        public IBaseRepository<ForgetPassword> ForgetPasswords { get; private set; }
        #endregion

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;

            #region SystemBase

            SystemRoles = new BaseRepository<SystemRole>(_context);
            SystemRoleFunctions = new BaseRepository<SystemRoleFunction>(_context);
            LogActions = new BaseRepository<LogAction>(_context);

            #endregion SystemBase

            #region UsersModule

            Users = new BaseRepository<User>(_context);
            UserProfiles = new BaseRepository<UserProfile>(_context);
            UserPatients = new BaseRepository<UserPatient>(_context);
            UserEmployees = new BaseRepository<UserEmployee>(_context);
            UserDoctors = new BaseRepository<UserDoctor>(_context);

            #endregion UsersModule

            #region ClinicModules

            Operations = new BaseRepository<Operation>(_context);
            NutritionalImprovements = new BaseRepository<NutritionalImprovement>(_context);
            Visits = new BaseRepository<Visit>(_context);
            MedicalHistories = new BaseRepository<MedicalHistory>(_context);

            #endregion ClinicModules

            #region AuthenticationModules 

            ForgetPasswords = new BaseRepository<ForgetPassword>(_context);


            #endregion
        }

        public async Task<int> CommitAsync()    
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose() => _context.Dispose();
    }
}