using App.Core.Interfaces.General.Scrutor;
using App.Core.Models.General.LocalModels;
using App.Core.Models.UsersModule._01._1_UserTypes.UserEmployee;


namespace App.Core.Interfaces.UsersModule.UserTypes.UserEmployees
{
    public interface IUserEmployeesValid : ITransientService
    {
        BaseValid IsValidUserEmployee(UserEmployee inputModel);
    }
}
