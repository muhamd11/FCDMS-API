using App.Core.Consts.GeneralModels;
using App.Core.Interfaces.SystemBase.LogActions;
using App.Core.Models.SystemBase._02_LogActions.DTO;
using App.Core.Models.SystemBase.LogActions.DTO;
using App.Core.Models.SystemBase.LogActions.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Api.Controllers.ClinicModules.LogActions
{
    [Route("api/[controller]")]
    [ApiController]
    public class LogActionsController : ControllerBase
    {
        #region Members

        //services
        private readonly ILogger<LogActionsController> _logger;

        private readonly ILogActionsValid _logActionsValid;
        private readonly ILogActionsServices _logActionsServices;

        //paramters
        private readonly string logActionInfoData = "logActionInfoData";

        private readonly string logActionsInfoData = "logActionsInfoData";
        private readonly string logActionInfoDetails = "logActionInfoDetails";

        #endregion Members

        #region Constructor

        public LogActionsController(ILogActionsValid logActionsValid, ILogActionsServices logActionsServices, ILogger<LogActionsController> logger)
        {
            _logger = logger;
            _logActionsValid = logActionsValid;
            _logActionsServices = logActionsServices;
        }

        #endregion Constructor

        #region Methods

        [HttpGet("GetLogActionDetails")]
        public async Task<IActionResult> GetLogActionDetails([FromQuery] LogActionGetDetails inputModel)
        {
            BaseGetDetailsResponse<LogActionInfoDetails> response = new();
            var watch = Stopwatch.StartNew();
            try
            {
                var isValidLogAction = _logActionsValid.ValidGetDetails(inputModel);
                if (isValidLogAction.Status != EnumStatus.success)
                    response = response.CreateResponse(isValidLogAction, logActionInfoDetails);
                else
                {
                    var logActionDetails = await _logActionsServices.GetDetails(inputModel);
                    response = response.CreateResponse(logActionDetails, logActionInfoDetails);
                }
            }
            catch (Exception ex)
            {
                response = response.CreateResponseCatch(logActionInfoDetails);
                _logger.LogError(ex, ex.Message);
            }
            finally
            {
                watch.Stop();
                response[nameof(response.executionTimeMilliseconds)] = watch.ElapsedMilliseconds;
            }
            return Ok(response);
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll([FromQuery] LogActionSearchDto inputModel)
        {
            BaseGetAllResponse<LogActionInfo> response = new();
            var watch = Stopwatch.StartNew();
            try
            {
                var isValidLogAction = _logActionsValid.ValidGetAll(inputModel);
                if (isValidLogAction.Status != EnumStatus.success)
                    response = response.CreateResponseError(isValidLogAction, logActionsInfoData);
                else
                {
                    var logAction = await _logActionsServices.GetAllAsync(inputModel);
                    response = response.CreateResponseSuccessOrNoContent(logAction, logActionsInfoData);
                }
            }
            catch (Exception ex)
            {
                response = response.CreateResponseCatch(logActionInfoData);
                _logger.LogError(ex, ex.Message);
            }
            finally
            {
                watch.Stop();
                response[nameof(response.executionTimeMilliseconds)] = watch.ElapsedMilliseconds;
            }
            return Ok(response);
        }

        //[HttpPost("AddLogAction")]
        //public async Task<IActionResult> AddLogAction([FromBody] LogActionAddOrUpdateDTO inputModel)
        //{
        //    string logActionInfoData = "logActionInfoData";
        //    BaseActionResponse<LogActionInfo> response = new();
        //    var watch = Stopwatch.StartNew();
        //    try
        //    {
        //        var isValidLogAction = _logActionsValid.ValidAddOrUpdate(inputModel, false);
        //        if (isValidLogAction.Status != EnumStatus.success)
        //            response = response.CreateResponse(isValidLogAction, logActionInfoData);
        //        else
        //        {
        //            var logActionData = await _logActionsServices.AddOrUpdate(inputModel, false);
        //            response = response.CreateResponse(logActionData, logActionInfoData);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        response = response.CreateResponseCatch(logActionInfoData);
        //        _logger.LogError(ex, ex.Message);
        //    }
        //    finally
        //    {
        //        watch.Stop();
        //        response[nameof(response.executionTimeMilliseconds)] = watch.ElapsedMilliseconds;
        //    }
        //    return Ok(response);
        //}

        //[HttpPost("UpdateLogAction")]
        //public async Task<IActionResult> UpdateLogAction([FromBody] LogActionAddOrUpdateDTO inputModel)
        //{
        //    string logActionInfoData = "logActionInfoData";
        //    BaseActionResponse<LogActionInfo> response = new();
        //    var watch = Stopwatch.StartNew();
        //    try
        //    {
        //        var isValidLogAction = _logActionsValid.ValidAddOrUpdate(inputModel, true);
        //        if (isValidLogAction.Status != EnumStatus.success)
        //            response = response.CreateResponse(isValidLogAction, logActionInfoData);
        //        else
        //        {
        //            var logActionData = await _logActionsServices.AddOrUpdate(inputModel, true);
        //            response = response.CreateResponse(logActionData, logActionInfoData);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        response = response.CreateResponseCatch(logActionInfoData);
        //        _logger.LogError(ex, ex.Message);
        //    }
        //    finally
        //    {
        //        watch.Stop();
        //        response[nameof(response.executionTimeMilliseconds)] = watch.ElapsedMilliseconds;
        //    }
        //    return Ok(response);
        //}

        //[HttpPost("DeleteLogAction")]
        //public async Task<IActionResult> DeleteLogAction([FromQuery] BaseDeleteDto inputModel)
        //{
        //    BaseActionResponse<LogActionInfo> response = new();
        //    var watch = Stopwatch.StartNew();
        //    try
        //    {
        //        var isValidLogAction = _logActionsValid.ValidDelete(inputModel);
        //        if (isValidLogAction.Status != EnumStatus.success)
        //        {
        //            response = response.CreateResponse(isValidLogAction, logActionInfoData);
        //        }
        //        else
        //        {
        //            var deletedLogAction = await _logActionsServices.DeleteAsync(inputModel);
        //            response = response.CreateResponse(deletedLogAction, logActionInfoData);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        response = response.CreateResponseCatch(logActionInfoData);
        //        _logger.LogError(ex, ex.Message);
        //    }
        //    finally
        //    {
        //        watch.Stop();
        //        response[nameof(response.executionTimeMilliseconds)] = watch.ElapsedMilliseconds;
        //    }
        //    return Ok(response);
        //}

        #endregion Methods
    }
}