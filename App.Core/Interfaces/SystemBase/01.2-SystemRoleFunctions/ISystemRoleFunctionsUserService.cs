using App.Core.Interfaces.General.Scrutor;
using App.Core.Models.SystemBase._01._2_SystemRoleFunctions;

namespace App.Core.Interfaces.SystemBase._01._2_SystemRoleFincations
{
    public interface ISystemRoleFunctionsUserService : ISingletonService
    {
        List<SystemRoleFunction> GetSystemRoleFunctions();
    }

    public interface ISystemRoleFunctionsMangerService : ISystemRoleFunctionsUserService
    {
    }

    public interface ISystemRoleFunctionsClientService : ISystemRoleFunctionsUserService
    {
    }
}