using App.Core.Consts.GeneralModels;
using App.Core.Interfaces.SystemBase.Visits;
using App.Core.Interfaces.UsersModule.UserAuthentications;
using App.Core.Models.ClinicModules.VisitsModules.DTO;
using App.Core.Models.ClinicModules.VisitsModules;
using App.Core.Models.General.BaseRequstModules;
using App.Core.Models.GeneralModels.BaseRequestHeaderModules;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Api.Controllers.ClinicModules.Visits
{
    [Route("api/[controller]")]
    [ApiController]
    public class VisitsController : ControllerBase
    {
        #region Members

        //services
        private readonly ILogger<VisitsController> _logger;

        private readonly IVisitsValid _visitsValid;
        private readonly IVisitsServices _visitsServices;
        private readonly IUserAuthValid _userAuthValid;

        //paramters
        private readonly string visitInfoData = "visitInfoData";

        private readonly string visitsInfoData = "visitsInfoData";
        private readonly string visitInfoDetails = "visitInfoDetails";

        #endregion Members

        #region Constructor

        public VisitsController(IVisitsValid visitsValid, IVisitsServices visitsServices, ILogger<VisitsController> logger, IUserAuthValid userAuthValid)
        {
            _logger = logger;
            _visitsValid = visitsValid;
            _visitsServices = visitsServices;
            _userAuthValid = userAuthValid;
        }

        #endregion Constructor

        #region Methods

        [HttpGet("GetVisitDetails")]
        public async Task<IActionResult> GetVisitDetails([FromQuery] VisitGetDetailsDTO inputModel, BaseRequestHeaders baseRequestHeaders)
        {
            BaseGetDetailsResponse<VisitInfoDetails> response = new();
            var watch = Stopwatch.StartNew();
            try
            {
                var isAuthenticated = _userAuthValid.IsAuthenticated(baseRequestHeaders);
                if (isAuthenticated.Status != EnumStatus.success)
                    response = response.CreateResponse(isAuthenticated, visitInfoDetails);
                else
                {
                    var isValidVisit = _visitsValid.ValidGetDetails(inputModel);
                    if (isValidVisit.Status != EnumStatus.success)
                        response = response.CreateResponse(isValidVisit, visitInfoDetails);
                    else
                    {
                        var visitDetails = await _visitsServices.GetDetails(inputModel);
                        response = response.CreateResponse(visitDetails, visitInfoDetails);
                    }
                }
            }
            catch (Exception ex)
            {
                response = response.CreateResponseCatch(visitInfoDetails);
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
        public async Task<IActionResult> GetAll([FromQuery] VisitSearchDTO inputModel, BaseRequestHeaders baseRequestHeaders)
        {
            BaseGetAllResponse<VisitInfo> response = new();
            var watch = Stopwatch.StartNew();
            try
            {
                var isAuthenticated = _userAuthValid.IsAuthenticated(baseRequestHeaders);
                if (isAuthenticated.Status != EnumStatus.success)
                    response = response.CreateResponseError(isAuthenticated, visitInfoDetails);
                else
                {
                    var isValidVisit = _visitsValid.ValidGetAll(inputModel);
                    if (isValidVisit.Status != EnumStatus.success)
                        response = response.CreateResponseError(isValidVisit, visitsInfoData);
                    else
                    {
                        var visit = await _visitsServices.GetAllAsync(inputModel);
                        response = response.CreateResponseSuccessOrNoContent(visit, visitsInfoData);
                    }
                }

            }
            catch (Exception ex)
            {
                response = response.CreateResponseCatch(visitInfoData);
                _logger.LogError(ex, ex.Message);
            }
            finally
            {
                watch.Stop();
                response[nameof(response.executionTimeMilliseconds)] = watch.ElapsedMilliseconds;
            }
            return Ok(response);
        }

        [HttpPost("AddVisit")]
        public async Task<IActionResult> AddVisit([FromBody] VisitAddOrUpdateDTO inputModel, BaseRequestHeaders baseRequestHeaders)
        {
            string visitInfoData = "visitInfoData";
            BaseActionResponse<VisitInfo> response = new();
            var watch = Stopwatch.StartNew();
            try
            {
                var isAuthenticated = _userAuthValid.IsAuthenticated(baseRequestHeaders);
                if (isAuthenticated.Status != EnumStatus.success)
                    response = response.CreateResponse(isAuthenticated, visitInfoDetails);
                else
                {
                    var isValidVisit = _visitsValid.ValidAddOrUpdate(inputModel, false);
                    if (isValidVisit.Status != EnumStatus.success)
                        response = response.CreateResponse(isValidVisit, visitInfoData);
                    else
                    {
                        var visitData = await _visitsServices.AddOrUpdate(inputModel, false);
                        response = response.CreateResponse(visitData, visitInfoData);
                    }
                }

            }
            catch (Exception ex)
            {
                response = response.CreateResponseCatch(visitInfoData);
                _logger.LogError(ex, ex.Message);
            }
            finally
            {
                watch.Stop();
                response[nameof(response.executionTimeMilliseconds)] = watch.ElapsedMilliseconds;
            }
            return Ok(response);
        }

        [HttpPost("UpdateVisit")]
        public async Task<IActionResult> UpdateVisit([FromBody] VisitAddOrUpdateDTO inputModel, BaseRequestHeaders baseRequestHeaders)
        {
            string visitInfoData = "visitInfoData";
            BaseActionResponse<VisitInfo> response = new();
            var watch = Stopwatch.StartNew();
            try
            {
                var isAuthenticated = _userAuthValid.IsAuthenticated(baseRequestHeaders);
                if (isAuthenticated.Status != EnumStatus.success)
                    response = response.CreateResponse(isAuthenticated, visitInfoDetails);
                else
                {
                    var isValidVisit = _visitsValid.ValidAddOrUpdate(inputModel, true);
                    if (isValidVisit.Status != EnumStatus.success)
                        response = response.CreateResponse(isValidVisit, visitInfoData);
                    else
                    {
                        var visitData = await _visitsServices.AddOrUpdate(inputModel, true);
                        response = response.CreateResponse(visitData, visitInfoData);
                    }
                }

            }
            catch (Exception ex)
            {
                response = response.CreateResponseCatch(visitInfoData);
                _logger.LogError(ex, ex.Message);
            }
            finally
            {
                watch.Stop();
                response[nameof(response.executionTimeMilliseconds)] = watch.ElapsedMilliseconds;
            }
            return Ok(response);
        }

        [HttpPost("DeleteVisit")]
        public async Task<IActionResult> DeleteVisit([FromQuery] BaseDeleteDto inputModel, BaseRequestHeaders baseRequestHeaders)
        {
            BaseActionResponse<VisitInfo> response = new();
            var watch = Stopwatch.StartNew();
            try
            {
                var isAuthenticated = _userAuthValid.IsAuthenticated(baseRequestHeaders);
                if (isAuthenticated.Status != EnumStatus.success)
                    response = response.CreateResponse(isAuthenticated, visitInfoDetails);
                else
                {
                    var isValidVisit = _visitsValid.ValidDelete(inputModel);
                    if (isValidVisit.Status != EnumStatus.success)
                    {
                        response = response.CreateResponse(isValidVisit, visitInfoData);
                    }
                    else
                    {
                        var deletedVisit = await _visitsServices.DeleteAsync(inputModel);
                        response = response.CreateResponse(deletedVisit, visitInfoData);
                    }
                }
            }
            catch (Exception ex)
            {
                response = response.CreateResponseCatch(visitInfoData);
                _logger.LogError(ex, ex.Message);
            }
            finally
            {
                watch.Stop();
                response[nameof(response.executionTimeMilliseconds)] = watch.ElapsedMilliseconds;
            }
            return Ok(response);
        }

        #endregion Methods
    }
}