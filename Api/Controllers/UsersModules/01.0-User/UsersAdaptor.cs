using Api.Controllers.SystemBase.BaseEntitys;
using Api.Controllers.SystemBase.SystemRoles;
using App.Core.Models.Users;
using System.Linq.Expressions;

namespace Api.Controllers.UsersModule.Users
{
    public static class UsersAdaptor
    {
        public static Expression<Func<User, UserInfo>> SelectExpressionUserClientInfo()
        {
            return user => new UserInfo
            {
                userToken = user.userToken,
                userName = user.userName,
                userEmail = user.userEmail,
                userPhone = user.userPhone,
                userType = user.userType,
                isDeleted = BaseEntitiesAdaptor.SelectExpressionBaseEntityInfo(user).isDeleted,
                createdDateTime = BaseEntitiesAdaptor.SelectExpressionBaseEntityInfo(user).createdDateTime,
                updatedDateTime = BaseEntitiesAdaptor.SelectExpressionBaseEntityInfo(user).updatedDateTime,
            };
        }

        public static Expression<Func<User, UserInfoDetails>> SelectExpressionUserClientDetails()
        {
            return user => new UserInfoDetails
            {
                userToken = user.userToken,
                userName = user.userName,
                userEmail = user.userEmail,
                userPhone = user.userPhone,
                userType = user.userType,
                isDeleted = BaseEntitiesAdaptor.SelectExpressionBaseEntityInfo(user).isDeleted,
                createdDateTime = BaseEntitiesAdaptor.SelectExpressionBaseEntityInfo(user).createdDateTime,
                updatedDateTime = BaseEntitiesAdaptor.SelectExpressionBaseEntityInfo(user).updatedDateTime,
                systemRoleToken = user.systemRoleToken,
                roleData = SystemRolesAdaptor.SelectExpressionSystemRoleInfo(user.roleData),
                userProfile = user.userProfile,
                userPatientInfo = UserPatientsAdaptor.SelectExpressionUserClientInfo(user.userPatientData),
            };
        }

        public static UserInfo SelectExpressionUserClientInfo(User user)
        {
            if (user == null)
                return null;

            return new UserInfo
            {
                userToken = user.userToken,
                userName = user.userName,
                userEmail = user.userEmail,
                userPhone = user.userPhone,
                userType = user.userType,
                isDeleted = BaseEntitiesAdaptor.SelectExpressionBaseEntityInfo(user).isDeleted,
                createdDateTime = BaseEntitiesAdaptor.SelectExpressionBaseEntityInfo(user).createdDateTime,
                updatedDateTime = BaseEntitiesAdaptor.SelectExpressionBaseEntityInfo(user).updatedDateTime,
            };
        }

        public static UserInfoDetails SelectExpressionUserClientDetails(User user)
        {
            if (user == null)
                return null;
            return new UserInfoDetails
            {
                userToken = user.userToken,
                userName = user.userName,
                userEmail = user.userEmail,
                userPhone = user.userPhone,
                userType = user.userType,
                isDeleted = BaseEntitiesAdaptor.SelectExpressionBaseEntityInfo(user).isDeleted,
                createdDateTime = BaseEntitiesAdaptor.SelectExpressionBaseEntityInfo(user).createdDateTime,
                updatedDateTime = BaseEntitiesAdaptor.SelectExpressionBaseEntityInfo(user).updatedDateTime,
                systemRoleToken = user.systemRoleToken,
                roleData = SystemRolesAdaptor.SelectExpressionSystemRoleInfo(user.roleData),
                userProfile = user.userProfile,
                userPatientInfo = UserPatientsAdaptor.SelectExpressionUserClientInfo(user.userPatientData),
            };
        }
    }
}