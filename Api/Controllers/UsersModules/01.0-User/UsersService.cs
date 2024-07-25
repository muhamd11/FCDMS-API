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
            var select = UsersAdaptor.SelectExpressionUserClientInfo();

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

            if (inputModel.elementToken is not null)
                criteria.Add(x => x.userToken == inputModel.elementToken);

            return criteria;
        }

        public async Task<UserInfoDetails> GetDetails(BaseGetDetailsDto inputModel)
        {
            var select = UsersAdaptor.SelectExpressionUserClientDetails();

            Expression<Func<User, bool>> criteria = (x) => x.userToken == inputModel.elementToken;

            List<Expression<Func<User, object>>> includes = [];

            includes.Add(x => x.roleData);
            includes.Add(x => x.userProfileData);

            var userInfo = await _unitOfWork.Users.FirstOrDefaultAsync(criteria, select, includes);

            return userInfo;
        }

        public async Task<BaseActionDone<UserInfo>> AddOrUpdate(UserAddOrUpdateDTO inputModel, bool isUpdate)
        {
            var user = _mapper.Map<User>(inputModel);

            if (isUpdate)
            {
                DeleteAllOldProfile(user.userToken);
                user = _unitOfWork.Users.Update(user);
            }
            else
                user = await _unitOfWork.Users.AddAsync(user);

            var isDone = await _unitOfWork.CommitAsync();

            if (isDone > 0)
                SyncProfiles(user.userToken, inputModel);

            var userInfo = await _unitOfWork.Users.FirstOrDefaultAsync(x => x.userToken == user.userToken, UsersAdaptor.SelectExpressionUserClientInfo());

            return BaseActionDone<UserInfo>.GenrateBaseActionDone(isDone, userInfo);
        }

        private async void SyncProfiles(Guid userToken, UserAddOrUpdateDTO inputModel)
        { 
            //userProfile scope
            {
                //null save
                inputModel.userProfileData = inputModel.userProfileData ?? new();
                inputModel.userProfileData.userToken = userToken;
                await _unitOfWork.UserProfiles.AddAsync(inputModel.userProfileData);
                await _unitOfWork.CommitAsync();
            }

            if (inputModel.userType == EnumUserType.Patient)
            {
                //null save
                inputModel.userPatientData = inputModel.userPatientData ?? new();
                inputModel.userPatientData.userToken = userToken;
                await _unitOfWork.UserPatients.AddAsync(inputModel.userPatientData);
                await _unitOfWork.CommitAsync();
            }
            else if (inputModel.userType == EnumUserType.Employee)
            {
                //null save
                inputModel.userEmployeeData = inputModel.userEmployeeData ?? new();
                inputModel.userEmployeeData.userToken = userToken;
                await _unitOfWork.UserEmployees.AddAsync(inputModel.userEmployeeData);
                await _unitOfWork.CommitAsync();
            }
        }

        private async void DeleteAllOldProfile(Guid? userToken)
        {
            if (userToken == null)
                return;

            //delete
            _unitOfWork.UserProfiles.AsQueryable().Where(x => x.userToken == userToken).ExecuteDelete();
            _unitOfWork.UserPatients.AsQueryable().Where(x => x.userToken == userToken).ExecuteDelete();
            _unitOfWork.UserEmployees.AsQueryable().Where(x => x.userToken == userToken).ExecuteDelete();
            await _unitOfWork.CommitAsync();
        }
        public async Task<BaseActionDone<UserInfo>> DeleteAsync(BaseDeleteDto inputModel)
        {
            var user = await _unitOfWork.Users.FirstOrDefaultAsync(x => x.userToken == inputModel.elementToken);

            _unitOfWork.Users.Delete(user);

            var isDone = await _unitOfWork.CommitAsync();

            var userInfo = await _unitOfWork.Users.FirstOrDefaultAsync(x => x.userToken == user.userToken, UsersAdaptor.SelectExpressionUserClientInfo());

            return BaseActionDone<UserInfo>.GenrateBaseActionDone(isDone, userInfo);
        }

        #endregion Methods
    }
}