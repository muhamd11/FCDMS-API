using App.Core.Interfaces.General.Scrutor;
using App.Core.Models.General.LocalModels;
using App.Core.Models.UsersModule._01_1_UserTypes;

namespace App.Core.Interfaces.UsersModule.UserTypes.UserProfiles
{
    public interface IUserProfileValid : ITransientService
    {
        BaseValid IsValidUserProfile(UserProfile inputModel);
    }
}