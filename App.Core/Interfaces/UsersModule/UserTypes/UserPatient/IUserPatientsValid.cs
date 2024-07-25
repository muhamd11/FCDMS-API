using App.Core.Interfaces.General.Scrutor;
using App.Core.Models.General.LocalModels;
using App.Core.Models.UsersModule._01_1_UserTypes._02_UserPatientData;

namespace Api.Controllers.UsersModules.Users.Interfaces
{
    public interface IUserPatientsValid : ITransientService
    {
        BaseValid IsValidUserClient(UserPatient inputModel);
    }
}