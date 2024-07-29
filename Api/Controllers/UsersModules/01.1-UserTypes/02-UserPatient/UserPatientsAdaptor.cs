using App.Core.Models.UsersModule._01._1_UserTypes._02_UserClientData.ViewModel;
using App.Core.Models.UsersModule._01_1_UserTypes._02_UserPatientData;
using System.Linq.Expressions;

namespace Api.Controllers.UsersModule.Users
{
    public static class UserPatientsAdaptor
    {
        public static Expression<Func<UserPatient, UserPatientInfo>> SelectExpressionUserPatientInfo()
        {
            return user => new UserPatientInfo
            {
                userPatientAge = user.userPatientAge,
                userPatientBloodType = user.userPatientBloodType,
                userPatientChildrenCount = user.userPatientChildrenCount,
            };
        }

        public static UserPatientInfo SelectExpressionUserPatientInfo(UserPatient user)
        {
            if (user == null)
                return null;

            return new UserPatientInfo
            {
                userPatientAge = user.userPatientAge,
                userPatientBloodType = user.userPatientBloodType,
                userPatientChildrenCount = user.userPatientChildrenCount,
            };
        }
    }
}