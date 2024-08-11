using Api.Controllers.SystemBase.BaseEntitys;
using Api.Controllers.SystemBase.SystemRoles;
using App.Core.Models.Users;
using System.Linq.Expressions;

namespace Api.Controllers.UsersModule.Users
{
    public static class UsersAdaptor
    {
        public static Expression<Func<User, UserInfo>> SelectExpressionUserInfo()
        {
            return user => new UserInfo
            {
                userToken = user.userToken,
                userName = user.userName,
                userEmail = user.userEmail,
                userPhone = user.userPhone,
                userLoginName = user.userLoginName,
                userTypeToken = user.userTypeToken,
                fullCode = user.fullCode,
                activationType = BaseEntitiesAdaptor.SelectExpressionBaseEntityInfo(user).activationType,
                createdDateTime = BaseEntitiesAdaptor.SelectExpressionBaseEntityInfo(user).createdDateTime,
                updatedDateTime = BaseEntitiesAdaptor.SelectExpressionBaseEntityInfo(user).updatedDateTime,
            };
        }

        public static Expression<Func<User, UserInfoDetails>> SelectExpressionUserInfoDetails()
        {
            return user => new UserInfoDetails
            {
                userToken = user.userToken,
                userName = user.userName,
                userEmail = user.userEmail!,
                userPhone = user.userPhone!,
                userLoginName = user.userLoginName!,
                userTypeToken = user.userTypeToken,
                fullCode = user.fullCode,
                activationType = BaseEntitiesAdaptor.SelectExpressionBaseEntityInfo(user).activationType,
                createdDateTime = BaseEntitiesAdaptor.SelectExpressionBaseEntityInfo(user).createdDateTime,
                updatedDateTime = BaseEntitiesAdaptor.SelectExpressionBaseEntityInfo(user).updatedDateTime,
                roleData = SystemRolesAdaptor.SelectExpressionSystemRoleInfo(user.roleData),
                userProfileData = user.userProfileData,
                userPatientInfoData = UserPatientsAdaptor.SelectExpressionUserPatientInfo(user.userPatientData),
                UserEmployeeInfoData = UserEmployeesAdaptor.SelectExpressionUserEmployeeInfo(user.userEmployeeData),
            };
        }

        public static UserInfo SelectExpressionUserInfo(User user)
        {
            if (user == null)
                return null;

            return new UserInfo
            {
                userToken = user.userToken,
                userName = user.userName,
                userEmail = user.userEmail,
                userPhone = user.userPhone,
                userLoginName = user.userLoginName,
                userTypeToken = user.userTypeToken,
                fullCode = user.fullCode,
                activationType = BaseEntitiesAdaptor.SelectExpressionBaseEntityInfo(user).activationType,
                createdDateTime = BaseEntitiesAdaptor.SelectExpressionBaseEntityInfo(user).createdDateTime,
                updatedDateTime = BaseEntitiesAdaptor.SelectExpressionBaseEntityInfo(user).updatedDateTime,
            };
        }

        public static UserInfoDetails SelectExpressionUserInfoDetails(User user)
        {
            if (user == null)
                return null;

            return new UserInfoDetails
            {
                userToken = user.userToken,
                userName = user.userName,
                userEmail = user.userEmail,
                userPhone = user.userPhone,
                userLoginName = user.userLoginName,
                userTypeToken = user.userTypeToken,
                fullCode = user.fullCode,
                activationType = BaseEntitiesAdaptor.SelectExpressionBaseEntityInfo(user).activationType,
                createdDateTime = BaseEntitiesAdaptor.SelectExpressionBaseEntityInfo(user).createdDateTime,
                updatedDateTime = BaseEntitiesAdaptor.SelectExpressionBaseEntityInfo(user).updatedDateTime,
                roleData = SystemRolesAdaptor.SelectExpressionSystemRoleInfo(user.roleData),
                userProfileData = user.userProfileData,
                userPatientInfoData = user.userPatientData != null ? UserPatientsAdaptor.SelectExpressionUserPatientInfo(user.userPatientData) : new(),
                UserEmployeeInfoData = user.userPatientData != null ? UserEmployeesAdaptor.SelectExpressionUserEmployeeInfo(user.userEmployeeData) : new(),
            };
        }
    }
}