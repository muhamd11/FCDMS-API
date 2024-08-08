using Api.Controllers.SystemBase._01._2_SystemRoleFunctions;
using Api.Controllers.SystemBase.LogActions.Interfaces;
using App.Core;
using App.Core.Consts.Users;
using App.Core.Interfaces.SystemBase._01._2_SystemRoleFincations;
using App.Core.Models.General.LocalModels;
using App.Core.Models.SystemBase._01._2_SystemRoleFunctions;
using App.Core.Models.SystemBase._01._2_SystemRoleFunctions.DTO;
using App.Core.Models.SystemBase._01._2_SystemRoleFunctions.ViewModel;
using App.Core.Models.SystemBase.Roles;
using Microsoft.EntityFrameworkCore;

namespace Api.Controllers.SystemBase.SystemRoleFunctions
{
    internal class SystemRoleFunctionService : ISystemRoleFunctionsService
    {
        #region Members

        private readonly IUnitOfWork _unitOfWork;
        private readonly ISystemRoleFunctionsClientService _systemRoleFunctionsClientService;
        private readonly ISystemRoleFunctionsMangerService _systemRoleFunctionsMangerService;

        #endregion Members

        #region Constructor

        public SystemRoleFunctionService(IUnitOfWork unitOfWork, ISystemRoleFunctionsClientService systemRoleFunctionsClientService, ISystemRoleFunctionsMangerService systemRoleFunctionsMangerService)

        {
            _unitOfWork = unitOfWork;
            _systemRoleFunctionsClientService = systemRoleFunctionsClientService;
            _systemRoleFunctionsMangerService = systemRoleFunctionsMangerService;
        }

        #endregion Constructor

        #region Methods

        public async Task<List<SystemRoleFunctionGrouped>> GetDetails(Guid systemRoleToken)
        {
            // Fetch the system role based on the given ID
            var systemRole = await _unitOfWork.SystemRoles.FirstOrDefaultAsync(x => x.systemRoleToken == systemRoleToken);

            // Fetch the system role functions for the given role ID from the database
            var systemRoleFunctionsInDB = await _unitOfWork.SystemRoleFunctions
                .AsQueryable()
                .Where(x => x.systemRoleToken == systemRoleToken)
                .ToListAsync() ?? new List<SystemRoleFunction>();

            // Get the detailed system role functions
            var systemRoleFunctions = GetSystemRoleFunctions(systemRole, systemRoleFunctionsInDB);

            return GetSystemRoleFunctionsGroupedByModuleId(systemRoleFunctions);
        }

        private List<SystemRoleFunctionGrouped> GetSystemRoleFunctionsGroupedByModuleId(List<SystemRoleFunction> systemRoleFunctions)
        {
            var trueSystemRoleFunctionsGroupedByModuleId = systemRoleFunctions.GroupBy(x => x.moduleId);

            List<SystemRoleFunctionGrouped> systemRoleFunctionsInfo = new();

            foreach (var item in trueSystemRoleFunctionsGroupedByModuleId)
            {
                systemRoleFunctionsInfo.Add(
                    new SystemRoleFunctionGrouped
                    {
                        systemRoleFunctionModule = item.Key,
                        systemRoleFunctions = item.Select(SystemRoleFunctionAdaptor.SelectExpressionSystemRoleFunctionInfo).ToList()
                    }
                    );
            }

            return systemRoleFunctionsInfo;
        }

        public async Task<BaseActionDone<List<SystemRoleFunction>>> UpdatePrivilege(SystemRoleFunctionDto inputModel)
        {
            // Delete existing functions for the given system role ID
            _unitOfWork.SystemRoleFunctions
                .AsQueryable()
                .Where(x => x.systemRoleToken == inputModel.systemRoleToken)
                .ExecuteDelete();

            // Commit the changes
            await _unitOfWork.CommitAsync();

            // Fetch the system role based on the input model's role ID
            var systemRole = await _unitOfWork.SystemRoles.FirstOrDefaultAsync(x => x.systemRoleToken == inputModel.systemRoleToken);

            // Get the detailed system role functions based on the input model
            List<SystemRoleFunction> systemRoleFunctions = GetSystemRoleFunctions(systemRole, inputModel.systemRoleFunctions.ToList());

            // Filter the functions that have privileges
            systemRoleFunctions = systemRoleFunctions.Where(x => x.isHavePrivilege).ToList();

            if (systemRoleFunctions.Count > 0)
            {
                // Add new functions with privileges
                await _unitOfWork.SystemRoleFunctions.AddRangeAsync(systemRoleFunctions);

                // Commit the changes
                var isDone = await _unitOfWork.CommitAsync();

                // Return success with the updated functions
                return BaseActionDone<List<SystemRoleFunction>>.GenrateBaseActionDone(isDone, systemRoleFunctions);
            }
            else
            {
                // Return success with no functions if none have privileges
                return BaseActionDone<List<SystemRoleFunction>>.GenrateBaseActionDone(1, systemRoleFunctions);
            }
        }

        private List<SystemRoleFunction> GetSystemRoleFunctions(SystemRole systemRole, List<SystemRoleFunction> inputSystemRoleFunctions)
        {
            List<SystemRoleFunction> trueSystemRoleFunction = new List<SystemRoleFunction>();

            // Determine the user type and fetch the corresponding functions
            if (systemRole.userTypeToken == EnumUserType.Doctor || systemRole.userTypeToken == EnumUserType.Developer)
                trueSystemRoleFunction = _systemRoleFunctionsMangerService.GetSystemRoleFunctions();
            else if (systemRole.userTypeToken == EnumUserType.Patient)
                trueSystemRoleFunction = _systemRoleFunctionsClientService.GetSystemRoleFunctions();

            // Migrate input functions and trueSystemRoleFincation, updating privileges
            trueSystemRoleFunction.ForEach(z =>
            {
                z.systemRoleToken = systemRole.systemRoleToken;
                z.isHavePrivilege = inputSystemRoleFunctions.FirstOrDefault(x => x.functionId == z.functionId, new SystemRoleFunction()).isHavePrivilege;
            });

            return trueSystemRoleFunction;
        }

        #endregion Methods
    }
}