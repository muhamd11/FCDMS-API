using App.Core.Interfaces.General.Scrutor;
using App.Core.Models.General.BaseRequstModules;
using App.Core.Models.General.LocalModels;
using App.Core.Models.Users;

namespace Api.Controllers.UsersModules.Users.Interfaces
{
    public interface IUsersValid : ITransientService
    {
        BaseValid ValidGetDetails(BaseGetDetailsDto inputModel);

        BaseValid ValidGetAll(BaseSearchDto inputModel);

        BaseValid ValidAddOrUpdate(UserAddOrUpdateDTO inputModel, bool isUpdate);

        BaseValid ValidUserData(UserAddOrUpdateDTO inputModel);

        BaseValid ValidDelete(BaseDeleteDto inputModel);

        BaseValid IsValidUserToken(Guid userToken);
    }
}