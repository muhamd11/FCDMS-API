using App.Core.Consts.GeneralModels;
using App.Core.Models.UsersModule._01._1_UserTypes.UserEmployee;
using App.Core.Models.UsersModule._01._1_UserTypes.UserEmployee.ViewModel;
using System.Linq.Expressions;

namespace Api.Controllers.UsersModule.Users
{
    public static class UserEmployeesAdaptor
    {
        public static Expression<Func<UserEmployee, UserEmployeeInfo>> SelectExpressionUserEmployeeInfo()
        {
            return user => new UserEmployeeInfo
            {
                userGender = (EnumGenderType)user.userGender!,
                userNationality = user.userNationality,
                userNationalId = user.userNationalId
            };
        }

        public static UserEmployeeInfo? SelectExpressionUserEmployeeInfo(UserEmployee? user)
        {
            if (user == null)
                return null;

            return new UserEmployeeInfo
            {
                userGender = (EnumGenderType)user.userGender!,
                userNationality = user.userNationality,
                userNationalId = user.userNationalId
            };
        }
    }
}