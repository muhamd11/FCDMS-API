using App.Core;
using App.Core.Consts.GeneralModels;
using App.Core.Consts.SystemBase;
using App.Core.Consts.Users;
using App.Core.Helper;
using App.Core.Helper.Validations;
using App.Core.Interfaces.UsersModule.Users;
using App.Core.Models.General.BaseRequstModules;
using App.Core.Models.General.LocalModels;
using App.Core.Models.General.PaginationModule;
using App.Core.Models.GeneralModels.BaseRequstModules;
using App.Core.Models.Users;
using App.Core.Models.UsersModule._01._2_UserAuthentications.SignUpModule.DTO;
using App.Core.Resources.General;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Api.Controllers.UsersModule.Users
{
    internal class UserService : IUsersServices
    {
        #region Members

        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        #endregion Members

        #region Constructor

        public UserService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        #endregion Constructor

        #region Methods

        public async Task<BaseGetDataWithPagnation<UserInfo>> GetAllAsync(UserSearchDto inputModel)
        {
            var select = UsersAdaptor.SelectExpressionUserInfo();

            var criteria = GenrateCriteria(inputModel);

            List<Expression<Func<User, object>>> includes = [];

            includes.Add(x => x.roleData);

            PaginationRequest paginationRequest = inputModel;

            return await _unitOfWork.Users.GetAllAsync(select, criteria, paginationRequest, includes);
        }

        private List<Expression<Func<User, bool>>> GenrateCriteria(UserSearchDto inputModel)
        {
            List<Expression<Func<User, bool>>> criteria = [];
            // TODO: Complete Search Function For User
            if (inputModel.textSearch is not null)
                criteria.Add(x => x.userName.Contains(inputModel.textSearch));

            if (inputModel.activationType is not null)
                criteria.Add(x => x.activationType == inputModel.activationType);

            if (inputModel.fullCode is not null)
                criteria.Add(x => x.fullCode!.Contains(inputModel.fullCode));

            if (inputModel.elementToken is not null)
                criteria.Add(x => x.userToken == inputModel.elementToken);

            if (inputModel.userTypeToken is not null)
                criteria.Add(x => x.userTypeToken == inputModel.userTypeToken);

            return criteria;
        }

        public async Task<UserInfoDetails> GetDetails(BaseGetDetailsDto inputModel)
        {
            var select = UsersAdaptor.SelectExpressionUserInfoDetails();

            Expression<Func<User, bool>> criteria = (x) => x.userToken == inputModel.elementToken;

            var includes = GenerateIncludes();

            var userInfo = await _unitOfWork.Users.FirstOrDefaultAsync(criteria, select);

            return userInfo;
        }

        private static List<Expression<Func<User, object>>> GenerateIncludes()
        {
            List<Expression<Func<User, object>>> includes = [];

            includes.Add(x => x.roleData);
            includes.Add(x => x.userProfileData);
            includes.Add(x => x.userPatientData);
            includes.Add(x => x.userEmployeeData);
            includes.Add(x => x.userDoctorData);
            return includes;
        }

        public async Task<BaseActionDone<UserInfo>> AddOrUpdate(UserAddOrUpdateDTO inputModel, bool isUpdate)
        {
            var userOnly = _mapper.Map<User>(inputModel);

            userOnly = AdaptationUserDataToAdd(userOnly);

            if (isUpdate)
            {
                await DeleteAllOldProfile(userOnly.userToken);

                var oldUser = _unitOfWork.Users.FirstOrDefault(x => x.userToken == inputModel.userToken);
                userOnly.userPassword = oldUser.userPassword; // prevent edit
                userOnly = _unitOfWork.Users.Update(userOnly);
            }
            else
                userOnly = await _unitOfWork.Users.AddAsync(userOnly);

            var isDone = await _unitOfWork.CommitAsync();

            if (isDone > 0)
                await AddNewProfiles(userOnly.userToken, inputModel);

            var userInfo = await _unitOfWork.Users.FirstOrDefaultAsync(x => x.userToken == userOnly.userToken, UsersAdaptor.SelectExpressionUserInfo());

            return BaseActionDone<UserInfo>.GenrateBaseActionDone(isDone, userInfo);
        }

        public async Task<BaseActionDone<UserInfo>> ChangeUserActivationType(BaseChangeActivationDto inputModel)
        {
            var user = await _unitOfWork.Users.FirstOrDefaultAsync(x => x.userToken == inputModel.elementToken);

            UserAddOrUpdateDTO userAddOrUpdateDTO = new()
            {
                userToken = user.userToken,
                userName = user.userName,
                userEmail = user.userEmail,
                userPhone = user.userPhone,
                userPhoneCC = user.userPhoneCC,
                userTypeToken = user.userTypeToken,
                userPhoneCCName = user.userPhoneCCName,
                userLoginName = user.userName,
                userPassword = user.userPassword,
                userProfileData = user.userProfileData,
                userPatientData = user.userPatientData,

                // Update User Activation Type
                activationType = inputModel.activationType
            };

            return await AddOrUpdate(userAddOrUpdateDTO, true);
        }

        public async Task<BaseActionDone<UserInfo>> AddFromSginUp(UserSignUpDto inputModel)
        {
            UserAddOrUpdateDTO userAddOrUpdateDTO = new()
            {
                userName = inputModel.userName,
                userEmail = inputModel.userEmail,
                userPhone = inputModel.userPhone,
                userPhoneCC = inputModel.userPhoneCC,
                userTypeToken = EnumUserType.Patient,
                userPhoneCCName = inputModel.userPhoneCCName,
                userLoginName = inputModel.userName,
                userPassword = inputModel.userPassword,
                userProfileData = inputModel.userProfileData,
                userPatientData = inputModel.userPatientData,
                activationType = EnumActivationType.active
            };

            return await AddOrUpdate(userAddOrUpdateDTO, false);
        }

        private async Task AddNewProfiles(Guid userToken, UserAddOrUpdateDTO inputModel)
        {
            //userProfile scope
            {
                //null safe
                inputModel.userProfileData = inputModel.userProfileData ?? new();
                inputModel.userProfileData.userToken = userToken;
                await _unitOfWork.UserProfiles.AddAsync(inputModel.userProfileData);
                await _unitOfWork.CommitAsync();
            }

            if (inputModel.userTypeToken == EnumUserType.Patient)
            {
                //null safe
                inputModel.userPatientData = inputModel.userPatientData ?? new();
                inputModel.userPatientData.userToken = userToken;
                await _unitOfWork.UserPatients.AddAsync(inputModel.userPatientData);
                await _unitOfWork.CommitAsync();
            }
            else if (inputModel.userTypeToken == EnumUserType.Employee)
            {
                //null safe
                inputModel.userEmployeeData = inputModel.userEmployeeData ?? new();
                inputModel.userEmployeeData.userToken = userToken;
                await _unitOfWork.UserEmployees.AddAsync(inputModel.userEmployeeData);
                await _unitOfWork.CommitAsync();
            }
            else if (inputModel.userTypeToken == EnumUserType.Doctor)
            {
                //null safe
                inputModel.userDoctorData = inputModel.userDoctorData ?? new();
                inputModel.userDoctorData.userToken = userToken;
                await _unitOfWork.UserDoctors.AddAsync(inputModel.userDoctorData);
                await _unitOfWork.CommitAsync();
            }
        }

        private User AdaptationUserDataToAdd(User user)
        {
            user = SetFullCode(user);
            user = SetSystemRole(user);
            user.userPassword = ValidationClass.IsValidString(user.userPassword) ? user.userPassword : ConstantStrings.defaultPassword;
            user.userPassword = MethodsClass.Encrypt_Base64(user.userPassword!);
            user.activationType = user.activationType == 0 ? EnumActivationType.active : user.activationType;
            user.userProfileData = null;
            user.userPatientData = null;
            user.userEmployeeData = null;
            user.userDoctorData = null;
            return user;
        }

        private User SetFullCode(User user)
        {
            if (!string.IsNullOrEmpty(user.fullCode))
            {
                user.primaryFullCode = $"{user.userTypeToken.ToString()}_{user.fullCode}";
                return user;
            }
            else
            {
                var totalCounts = _unitOfWork.Users.Count(x => x.userTypeToken == user.userTypeToken);
                user.primaryFullCode = $"{user.userTypeToken.ToString()}_{1 + totalCounts}";
                user.fullCode = (1 + totalCounts).ToString();
                return user;
            }
        }

        private User SetSystemRole(User user)
        {
            if (user.systemRoleToken.HasValue == true)
                return user;
            else
            {
                var systemRole = _unitOfWork.SystemRoles.FirstOrDefault(x => x.systemRoleCanUseDefault == true && x.systemRoleUserTypeToken == user.userTypeToken);
                user.systemRoleToken = systemRole.systemRoleToken;
                return user;
            }
        }

        private async Task DeleteAllOldProfile(Guid? userToken)
        {
            if (userToken == null)
                return;

            //delete
            _unitOfWork.UserProfiles.AsQueryable().Where(x => x.userToken == userToken).ExecuteDelete();
            _unitOfWork.UserPatients.AsQueryable().Where(x => x.userToken == userToken).ExecuteDelete();
            _unitOfWork.UserEmployees.AsQueryable().Where(x => x.userToken == userToken).ExecuteDelete();
            _unitOfWork.UserDoctors.AsQueryable().Where(x => x.userToken == userToken).ExecuteDelete();
            await _unitOfWork.CommitAsync();
        }

        public async Task<BaseActionDone<UserInfo>> DeleteAsync(BaseDeleteDto inputModel)
        {
            var user = await _unitOfWork.Users.FirstOrDefaultAsync(x => x.userToken == inputModel.elementToken);

            await DeleteAllOldProfile(user.userToken);

            _unitOfWork.Users.Delete(user);

            var isDone = await _unitOfWork.CommitAsync();

            return BaseActionDone<UserInfo>.GenrateBaseActionDone(isDone, UsersAdaptor.SelectExpressionUserInfo(user));
        }

        #endregion Methods
    }
}