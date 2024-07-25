using App.Core.Interfaces.General.Scrutor;
using App.Core.Models.Buyers;
using App.Core.Models.General.LocalModels;

namespace App.Core.Interfaces.UsersModule.UserTypes.UserProfiles
{
    public interface IUserProfileValid : ITransientService
    {
        BaseValid IsValidUserProfile(UserProfile inputModel);
    }
}