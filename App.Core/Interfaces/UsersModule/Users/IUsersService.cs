using App.Core.Interfaces.General.Scrutor;
using App.Core.Models.General.BaseRequstModules;
using App.Core.Models.General.LocalModels;
using App.Core.Models.Users;
using System.Threading.Tasks;

namespace App.Core.Interfaces.UsersModule.Users
{
    public interface IUsersServices : ITransientService
    {
        Task<BaseGetDataWithPagnation<UserInfo>> GetAllAsync(UserSearchDto inputModel);

        Task<UserInfoDetails> GetDetails(BaseGetDetailsDto inputModel);

        Task<BaseActionDone<UserInfo>> AddOrUpdate(UserAddOrUpdateDTO inputModel, bool isUpdate);

        Task<BaseActionDone<UserInfo>> DeleteAsync(BaseDeleteDto inputModel);
    }
}