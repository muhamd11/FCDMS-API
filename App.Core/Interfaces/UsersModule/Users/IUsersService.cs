using App.Core.Interfaces.General.Scrutor;
using App.Core.Models.General.BaseRequstModules;
using App.Core.Models.General.LocalModels;
using App.Core.Models.GeneralModels.BaseRequstModules;
using App.Core.Models.Users;
using App.Core.Models.UsersModule._01._2_UserAuthentications.SignUpModule.DTO;

namespace App.Core.Interfaces.UsersModule.Users
{
    public interface IUsersServices : ITransientService
    {
        Task<BaseGetDataWithPagnation<UserInfo>> GetAllAsync(UserSearchDto inputModel);

        Task<UserInfoDetails> GetDetails(BaseGetDetailsDto inputModel);

        Task<BaseActionDone<UserInfo>> AddOrUpdate(UserAddOrUpdateDTO inputModel, bool isUpdate);

        Task<BaseActionDone<UserInfo>> AddFromSginUp(UserSignUpDto inputModel);

        Task<BaseActionDone<UserInfo>> ChangeUserActivationType(BaseChangeActivationDto inputModel);

        Task<BaseActionDone<UserInfo>> DeleteAsync(BaseDeleteDto inputModel);

    }
}