using App.Core;
using App.Core.Consts.Users;
using App.Core.Helper;
using App.Core.Interfaces.UsersModule.Users;
using App.Core.Models.General.BaseRequstModules;
using App.Core.Models.General.LocalModels;
using App.Core.Models.General.PaginationModule;
using App.Core.Models.Users;
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
            {
                criteria.Add(x =>
                x.userName.Contains(inputModel.textSearch));
            }

            if (inputModel.fullCode is not null)
                criteria.Add(x => x.fullCode.Contains(inputModel.fullCode));

            if (inputModel.elementToken is not null)
                criteria.Add(x => x.userToken == inputModel.elementToken);

            return criteria;
        }

        public async Task<UserInfoDetails> GetDetails(BaseGetDetailsDto inputModel)
        {
            var select = UsersAdaptor.SelectExpressionUserInfoDetails();

            Expression<Func<User, bool>> criteria = (x) => x.userToken == inputModel.elementToken;

            var includes = GenerateIncludes();

            var userInfo = await _unitOfWork.Users.FirstOrDefaultAsync(criteria, select, includes);

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

            userOnly = GetUserOnlyWithoutProfiles(userOnly);

            if (isUpdate)
            {
                await DeleteAllOldProfile(userOnly.userToken);
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

            if (inputModel.userType == EnumUserType.Patient)
            {
                //null safe
                inputModel.userPatientData = inputModel.userPatientData ?? new();
                inputModel.userPatientData.userToken = userToken;
                await _unitOfWork.UserPatients.AddAsync(inputModel.userPatientData);
                await _unitOfWork.CommitAsync();
            }
            else if (inputModel.userType == EnumUserType.Employee)
            {
                //null safe
                inputModel.userEmployeeData = inputModel.userEmployeeData ?? new();
                inputModel.userEmployeeData.userToken = userToken;
                await _unitOfWork.UserEmployees.AddAsync(inputModel.userEmployeeData);
                await _unitOfWork.CommitAsync();
            }
            else if (inputModel.userType == EnumUserType.Doctor)
            {
                //null safe
                inputModel.userDoctorData = inputModel.userDoctorData ?? new();
                inputModel.userDoctorData.userToken = userToken;
                await _unitOfWork.UserDoctors.AddAsync(inputModel.userDoctorData);
                await _unitOfWork.CommitAsync();
            }
        }

        private User GetUserOnlyWithoutProfiles(User user)
        {
            user.userPassword = MethodsClass.Encrypt_Base64(user.userPassword);
            user.userProfileData = null;
            user.userPatientData = null;
            user.userEmployeeData = null;
            user.userDoctorData = null;
            return user;
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