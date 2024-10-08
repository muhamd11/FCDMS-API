﻿using App.Core.Interfaces.General.Scrutor;
using App.Core.Models.General.LocalModels;
using App.Core.Models.SystemBase._01._2_SystemRoleFunctions;
using App.Core.Models.SystemBase._01._2_SystemRoleFunctions.DTO;
using App.Core.Models.SystemBase._01._2_SystemRoleFunctions.ViewModel;

namespace Api.Controllers.SystemBase.LogActions.Interfaces
{
    public interface ISystemRoleFunctionsService : ITransientService
    {
        Task<List<SystemRoleFunctionGrouped>> GetDetails(Guid systemRoleToken);

        Task<BaseActionDone<List<SystemRoleFunction>>> UpdatePrivilege(SystemRoleFunctionDto inputModel);
    }
}