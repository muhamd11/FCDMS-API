using App.Core.Consts.GeneralModels;
using App.Core.Interfaces.SystemBase.NutritionalImprovements;
using App.Core.Interfaces.SystemBase.NutritionalImprovements;
using App.Core.Models.ClinicModules.NutritionalImprovementsModules.DTO;
using App.Core.Models.ClinicModules.NutritionalImprovementsModules.ViewModel;
using App.Core.Models.ClinicModules.NutritionalImprovementsModules;
using App.Core.Models.General.BaseRequstModules;
using App.Core.Models.GeneralModels.BaseRequstModules;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Api.Controllers.SystemBase.NutritionalImprovements
{
    [Route("api/[controller]")]
    [ApiController]
    public class NutritionalImprovementsController : ControllerBase
    {
        #region Members

        //services
        private readonly ILogger<NutritionalImprovementsController> _logger;

        private readonly INutritionalImprovementsValid _nutritionalImprovementsValid;
        private readonly INutritionalImprovementsServices _nutritionalImprovementsServices;

        //paramters
        private readonly string nutritionalImprovementInfoData = "nutritionalImprovementInfoData";

        private readonly string nutritionalImprovementsInfoData = "nutritionalImprovementsInfoData";
        private readonly string nutritionalImprovementInfoDetails = "nutritionalImprovementInfoDetails";

        #endregion Members

        #region Constructor

        public NutritionalImprovementsController(INutritionalImprovementsValid nutritionalImprovementsValid, INutritionalImprovementsServices nutritionalImprovementsServices, ILogger<NutritionalImprovementsController> logger)
        {
            _logger = logger;
            _nutritionalImprovementsValid = nutritionalImprovementsValid;
            _nutritionalImprovementsServices = nutritionalImprovementsServices;
        }

        #endregion Constructor

        #region Methods

        [HttpGet("GetNutritionalImprovementDetails")]
        public async Task<IActionResult> GetNutritionalImprovementDetails([FromQuery] NutritionalImprovementGetDetailsDTO inputModel)
        {
            BaseGetDetailsResponse<NutritionalImprovementInfoDetails> response = new();
            var watch = Stopwatch.StartNew();
            try
            {
                var isValidNutritionalImprovement = _nutritionalImprovementsValid.ValidGetDetails(inputModel);
                if (isValidNutritionalImprovement.Status != EnumStatus.success)
                    response = response.CreateResponse(isValidNutritionalImprovement, nutritionalImprovementInfoDetails);
                else
                {
                    var nutritionalImprovementDetails = await _nutritionalImprovementsServices.GetDetails(inputModel);
                    response = response.CreateResponse(nutritionalImprovementDetails, nutritionalImprovementInfoDetails);
                }
            }
            catch (Exception ex)
            {
                response = response.CreateResponseCatch(nutritionalImprovementInfoDetails);
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
        public async Task<IActionResult> GetAll([FromQuery] NutritionalImprovementSearchDTO inputModel)
        {
            BaseGetAllResponse<NutritionalImprovementInfo> response = new();
            var watch = Stopwatch.StartNew();
            try
            {
                var isValidNutritionalImprovement = _nutritionalImprovementsValid.ValidGetAll(inputModel);
                if (isValidNutritionalImprovement.Status != EnumStatus.success)
                    response = response.CreateResponseError(isValidNutritionalImprovement, nutritionalImprovementsInfoData);
                else
                {
                    var nutritionalImprovement = await _nutritionalImprovementsServices.GetAllAsync(inputModel);
                    response = response.CreateResponseSuccessOrNoContent(nutritionalImprovement, nutritionalImprovementsInfoData);
                }
            }
            catch (Exception ex)
            {
                response = response.CreateResponseCatch(nutritionalImprovementInfoData);
                _logger.LogError(ex, ex.Message);
            }
            finally
            {
                watch.Stop();
                response[nameof(response.executionTimeMilliseconds)] = watch.ElapsedMilliseconds;
            }
            return Ok(response);
        }

        [HttpPost("AddNutritionalImprovement")]
        public async Task<IActionResult> AddNutritionalImprovement([FromBody] NutritionalImprovementAddOrUpdateDTO inputModel)
        {
            string nutritionalImprovementInfoData = "nutritionalImprovementInfoData";
            BaseActionResponse<NutritionalImprovementInfo> response = new();
            var watch = Stopwatch.StartNew();
            try
            {
                var isValidNutritionalImprovement = _nutritionalImprovementsValid.ValidAddOrUpdate(inputModel, false);
                if (isValidNutritionalImprovement.Status != EnumStatus.success)
                    response = response.CreateResponse(isValidNutritionalImprovement, nutritionalImprovementInfoData);
                else
                {
                    var nutritionalImprovementData = await _nutritionalImprovementsServices.AddOrUpdate(inputModel, false);
                    response = response.CreateResponse(nutritionalImprovementData, nutritionalImprovementInfoData);
                }
            }
            catch (Exception ex)
            {
                response = response.CreateResponseCatch(nutritionalImprovementInfoData);
                _logger.LogError(ex, ex.Message);
            }
            finally
            {
                watch.Stop();
                response[nameof(response.executionTimeMilliseconds)] = watch.ElapsedMilliseconds;
            }
            return Ok(response);
        }

        [HttpPost("UpdateNutritionalImprovement")]
        public async Task<IActionResult> UpdateNutritionalImprovement([FromBody] NutritionalImprovementAddOrUpdateDTO inputModel)
        {
            string nutritionalImprovementInfoData = "nutritionalImprovementInfoData";
            BaseActionResponse<NutritionalImprovementInfo> response = new();
            var watch = Stopwatch.StartNew();
            try
            {
                var isValidNutritionalImprovement = _nutritionalImprovementsValid.ValidAddOrUpdate(inputModel, true);
                if (isValidNutritionalImprovement.Status != EnumStatus.success)
                    response = response.CreateResponse(isValidNutritionalImprovement, nutritionalImprovementInfoData);
                else
                {
                    var nutritionalImprovementData = await _nutritionalImprovementsServices.AddOrUpdate(inputModel, true);
                    response = response.CreateResponse(nutritionalImprovementData, nutritionalImprovementInfoData);
                }
            }
            catch (Exception ex)
            {
                response = response.CreateResponseCatch(nutritionalImprovementInfoData);
                _logger.LogError(ex, ex.Message);
            }
            finally
            {
                watch.Stop();
                response[nameof(response.executionTimeMilliseconds)] = watch.ElapsedMilliseconds;
            }
            return Ok(response);
        }

        [HttpPost("DeleteNutritionalImprovement")]
        public async Task<IActionResult> DeleteNutritionalImprovement([FromQuery] BaseDeleteDto inputModel)
        {
            BaseActionResponse<NutritionalImprovementInfo> response = new();
            var watch = Stopwatch.StartNew();
            try
            {
                var isValidNutritionalImprovement = _nutritionalImprovementsValid.ValidDelete(inputModel);
                if (isValidNutritionalImprovement.Status != EnumStatus.success)
                {
                    response = response.CreateResponse(isValidNutritionalImprovement, nutritionalImprovementInfoData);
                }
                else
                {
                    var deletedNutritionalImprovement = await _nutritionalImprovementsServices.DeleteAsync(inputModel);
                    response = response.CreateResponse(deletedNutritionalImprovement, nutritionalImprovementInfoData);
                }
            }
            catch (Exception ex)
            {
                response = response.CreateResponseCatch(nutritionalImprovementInfoData);
                _logger.LogError(ex, ex.Message);
            }
            finally
            {
                watch.Stop();
                response[nameof(response.executionTimeMilliseconds)] = watch.ElapsedMilliseconds;
            }
            return Ok(response);
        }

        [HttpPost("ChangeNutritionalImprovementActivationType")]
        public async Task<IActionResult> ChangeNutritionalImprovementActivationType([FromQuery] BaseChangeActivationDto inputModel)
        {
            BaseActionResponse<NutritionalImprovementInfo> response = new();
            var watch = Stopwatch.StartNew();
            try
            {
                var isValidUser = _nutritionalImprovementsValid.isValidChangeActivationTypeNutritionalImprovement(inputModel);
                if (isValidUser.Status != EnumStatus.success)
                    response = response.CreateResponse(isValidUser, nutritionalImprovementInfoData);
                else
                {
                    var userData = await _nutritionalImprovementsServices.ChangeNutritionalImprovementActivationType(inputModel);
                    response = response.CreateResponse(userData, nutritionalImprovementInfoData);
                }
            }
            catch (Exception ex)
            {
                response = response.CreateResponseCatch(nutritionalImprovementInfoData);
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