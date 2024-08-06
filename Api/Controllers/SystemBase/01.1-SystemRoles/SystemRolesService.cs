using App.Core;
using App.Core.Interfaces.SystemBase.SystemRoles;
using App.Core.Models.General.BaseRequstModules;
using App.Core.Models.General.LocalModels;
using App.Core.Models.General.PaginationModule;
using App.Core.Models.SystemBase.Roles;
using App.Core.Models.SystemBase.Roles.DTO;
using App.Core.Models.SystemBase.Roles.ViewModel;
using App.Core.Models.Users;
using AutoMapper;
using System.Linq.Expressions;

namespace Api.Controllers.SystemBase.SystemRoles
{
    internal class SystemRoleService : ISystemRolesServices
    {
        #region Members

        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        #endregion Members

        #region Constructor

        public SystemRoleService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        #endregion Constructor

        #region Methods

        public async Task<BaseGetDataWithPagnation<SystemRoleInfo>> GetAllAsync(SystemRoleSearchDto inputModel)
        {
            var select = SystemRolesAdaptor.SelectExpressionSystemRoleInfo();

            var criteria = GenrateCriteria(inputModel);

            PaginationRequest paginationRequest = inputModel;

            return await _unitOfWork.SystemRoles.GetAllAsync(select, criteria, paginationRequest);
        }

        private List<Expression<Func<SystemRole, bool>>> GenrateCriteria(SystemRoleSearchDto inputModel)
        {
            List<Expression<Func<SystemRole, bool>>> criteria = [];

            if (inputModel.textSearch is not null)
            {
                criteria.Add(x =>
                x.systemRoleName.Contains(inputModel.textSearch)
                || x.systemRoleDescription.Contains(inputModel.textSearch));
            }

            if (inputModel.systemRoleUserTypeToken.HasValue)
                criteria.Add(x => x.systemRoleUserTypeToken == inputModel.systemRoleUserTypeToken.Value);

            if(inputModel.fullCode is not null)
                criteria.Add(x => x.fullCode == inputModel.fullCode);

            if (inputModel.elementToken is not null)
                criteria.Add(x => x.systemRoleToken == inputModel.elementToken);

            return criteria;
        }

        public async Task<SystemRoleInfoDetails> GetDetails(BaseGetDetailsDto inputModel)
        {
            var select = SystemRolesAdaptor.SelectExpressionSystemRoleDetails();

            Expression<Func<SystemRole, bool>> criteria = (x) => x.systemRoleToken == inputModel.elementToken;

            List<Expression<Func<SystemRole, object>>> includes = [];

            includes.Add(x => x.usersData);

            var systemRoleInfo = await _unitOfWork.SystemRoles.FirstOrDefaultAsync(criteria, select, includes);

            return systemRoleInfo;
        }

        public async Task<BaseActionDone<SystemRoleInfo>> AddOrUpdate(SystemRoleAddOrUpdateDTO inputModel, bool isUpdate)
        {
            var systemRole = _mapper.Map<SystemRole>(inputModel);
            systemRole = SetFullCode(systemRole);

            if (isUpdate)
                _unitOfWork.SystemRoles.Update(systemRole);
            else
                await _unitOfWork.SystemRoles.AddAsync(systemRole);

            var isDone = await _unitOfWork.CommitAsync();

            var systemRoleInfo = await _unitOfWork.SystemRoles.FirstOrDefaultAsync(x => x.systemRoleToken == systemRole.systemRoleToken, SystemRolesAdaptor.SelectExpressionSystemRoleDetails());

            return BaseActionDone<SystemRoleInfo>.GenrateBaseActionDone(isDone, systemRoleInfo);
        }

        private SystemRole SetFullCode(SystemRole systemRole)
        {
            if (!string.IsNullOrEmpty(systemRole.fullCode))
            {
                systemRole.primaryFullCode = $"{systemRole.systemRoleUserTypeToken.ToString()}_{systemRole.fullCode}";
                return systemRole;
            }
            else
            {
                var totalCounts = _unitOfWork.SystemRoles.Count(x => x.systemRoleUserTypeToken == systemRole.systemRoleUserTypeToken);
                systemRole.primaryFullCode = $"{systemRole.systemRoleUserTypeToken.ToString()}_{1 + totalCounts}";
                systemRole.fullCode = (1 + totalCounts).ToString();
                return systemRole;
            }
        }

        public async Task<BaseActionDone<SystemRoleInfo>> DeleteAsync(BaseDeleteDto inputModel)
        {
            var systemRole = await _unitOfWork.SystemRoles.FirstOrDefaultAsync(x => x.systemRoleToken == inputModel.elementToken);

            _unitOfWork.SystemRoles.Delete(systemRole);

            var isDone = await _unitOfWork.CommitAsync();

            var systemRoleInfo =  SystemRolesAdaptor.SelectExpressionSystemRoleInfo(systemRole);

            return BaseActionDone<SystemRoleInfo>.GenrateBaseActionDone(isDone, systemRoleInfo);
        }

        #endregion Methods
    }
}