using App.Core;
using App.Core.Interfaces.SystemBase.LogActions;
using App.Core.Models.General.LocalModels;
using App.Core.Models.General.PaginationModule;
using App.Core.Models.SystemBase._02_LogActions.DTO;
using App.Core.Models.SystemBase.LogActions;
using App.Core.Models.SystemBase.LogActions.DTO;
using App.Core.Models.SystemBase.LogActions.ViewModel;

using AutoMapper;
using System.Linq.Expressions;

namespace Api.Controllers.SystemBase.LogActions
{
    internal class LogActionService : ILogActionsServices
    {
        #region Members

        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        #endregion Members

        #region Constructor

        public LogActionService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        #endregion Constructor

        #region Methods

        public async Task<BaseGetDataWithPagnation<LogActionInfo>> GetAllAsync(LogActionSearchDto inputModel)
        {
            var select = LogActionsAdaptor.SelectExpressionLogActionInfo(inputModel.includeUserInfoData);

            var criteria = GenrateCriteria(inputModel);

            PaginationRequest paginationRequest = inputModel;

            return await _unitOfWork.LogActions.GetAllAsync(select, criteria, paginationRequest);
        }

        private List<Expression<Func<LogAction, bool>>> GenrateCriteria(LogActionSearchDto inputModel)
        {
            List<Expression<Func<LogAction, bool>>> criteria = [];

            if (inputModel.textSearch is not null)
            {
                criteria.Add(x =>
                x.actionType.Contains(inputModel.textSearch)
                || x.modelName.Contains(inputModel.textSearch));
            }

            if (inputModel.userToken.HasValue)
                criteria.Add(x => x.userToken == inputModel.userToken.Value);

            if (inputModel.elementToken is not null)
                criteria.Add(x => x.logActionId.ToString() == inputModel.elementToken.ToString());

            return criteria;
        }

        public async Task<LogActionInfoDetails> GetDetails(LogActionGetDetails inputModel)
        {
            var select = LogActionsAdaptor.SelectExpressionLogActionDetails();

            Expression<Func<LogAction, bool>> criteria = (x) => x.logActionId == inputModel.logActionId;

            List<Expression<Func<LogAction, object>>> includes = [];

            includes.Add(x => x.userData);

            var logActionInfo = await _unitOfWork.LogActions.FirstOrDefaultAsync(criteria, select, includes);

            return logActionInfo;
        }

        #endregion Methods
    }
}