using Api.Controllers.UsersModules._01._2_UserAuthentications._0._2_Filters;
using App.Core.Consts.GeneralModels;
using App.Core.Interfaces.SystemBase.MedicalHistories;
using App.Core.Interfaces.UsersModule.UserAuthentications;
using App.Core.Models.ClinicModules.MedicalHistoriesModules.DTO;
using App.Core.Models.ClinicModules.MedicalHistoriesModules.ViewModel;
using App.Core.Models.General.BaseRequstModules;
using App.Core.Models.GeneralModels.BaseRequestHeaderModules;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Api.Controllers.ClinicModules.MedicalHistories
{
    [Route("api/[controller]")]
    [ApiController]
    [Authenticate]
    public class MedicalHistoriesController : ControllerBase
    {
        #region Members

        //services
        private readonly ILogger<MedicalHistoriesController> _logger;
        private readonly IMedicalHistoriesValid _medicalHistoriesValid;
        private readonly IMedicalHistoriesServices _medicalHistoriesServices;

        //paramters
        private readonly string medicalHistoryInfoData = "medicalHistoryInfoData";
        private readonly string medicalHistoriesInfoData = "medicalHistoriesInfoData";
        private readonly string medicalHistoryInfoDetails = "medicalHistoryInfoDetails";

        #endregion Members

        #region Constructor

        public MedicalHistoriesController(IMedicalHistoriesValid medicalHistoriesValid, IMedicalHistoriesServices medicalHistoriesServices, ILogger<MedicalHistoriesController> logger)
        {
            _logger = logger;
            _medicalHistoriesValid = medicalHistoriesValid;
            _medicalHistoriesServices = medicalHistoriesServices;
        }

        #endregion Constructor

        #region Methods

        [HttpGet("GetMedicalHistoryDetails")]
        public async Task<IActionResult> GetMedicalHistoryDetails([FromQuery] MedicalHistoryGetDetailsDTO inputModel)
        {
            BaseGetDetailsResponse<MedicalHistoryInfoDetails> response = new();
            var watch = Stopwatch.StartNew();
            try
            {
                var isValidMedicalHistory = _medicalHistoriesValid.ValidGetDetails(inputModel);
                if (isValidMedicalHistory.Status != EnumStatus.success)
                    response = response.CreateResponse(isValidMedicalHistory, medicalHistoryInfoDetails);
                else
                {
                    var medicalHistoryDetails = await _medicalHistoriesServices.GetDetails(inputModel);
                    response = response.CreateResponse(medicalHistoryDetails, medicalHistoryInfoDetails);
                }
            }
            catch (Exception ex)
            {
                response = response.CreateResponseCatch(medicalHistoryInfoDetails);
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
        public async Task<IActionResult> GetAll([FromQuery] MedicalHistorySearchDTO inputModel)
        {
            BaseGetAllResponse<MedicalHistoryInfo> response = new();
            var watch = Stopwatch.StartNew();
            try
            {
                var isValidMedicalHistory = _medicalHistoriesValid.ValidGetAll(inputModel);
                if (isValidMedicalHistory.Status != EnumStatus.success)
                    response = response.CreateResponseError(isValidMedicalHistory, medicalHistoriesInfoData);
                else
                {
                    var medicalHistory = await _medicalHistoriesServices.GetAllAsync(inputModel);
                    response = response.CreateResponseSuccessOrNoContent(medicalHistory, medicalHistoriesInfoData);
                }
            }
            catch (Exception ex)
            {
                response = response.CreateResponseCatch(medicalHistoryInfoData);
                _logger.LogError(ex, ex.Message);
            }
            finally
            {
                watch.Stop();
                response[nameof(response.executionTimeMilliseconds)] = watch.ElapsedMilliseconds;
            }
            return Ok(response);
        }

        [HttpPost("AddMedicalHistory")]
        public async Task<IActionResult> AddMedicalHistory([FromBody] MedicalHistoryAddOrUpdateDTO inputModel)
        {
            string medicalHistoryInfoData = "medicalHistoryInfoData";
            BaseActionResponse<MedicalHistoryInfo> response = new();
            var watch = Stopwatch.StartNew();
            try
            {
                var isValidMedicalHistory = _medicalHistoriesValid.ValidAddOrUpdate(inputModel, false);
                if (isValidMedicalHistory.Status != EnumStatus.success)
                    response = response.CreateResponse(isValidMedicalHistory, medicalHistoryInfoData);
                else
                {
                    var medicalHistoryData = await _medicalHistoriesServices.AddOrUpdate(inputModel, false);
                    response = response.CreateResponse(medicalHistoryData, medicalHistoryInfoData);
                }
            }
            catch (Exception ex)
            {
                response = response.CreateResponseCatch(medicalHistoryInfoData);
                _logger.LogError(ex, ex.Message);
            }
            finally
            {
                watch.Stop();
                response[nameof(response.executionTimeMilliseconds)] = watch.ElapsedMilliseconds;
            }
            return Ok(response);
        }

        [HttpPost("UpdateMedicalHistory")]
        public async Task<IActionResult> UpdateMedicalHistory([FromBody] MedicalHistoryAddOrUpdateDTO inputModel)
        {
            string medicalHistoryInfoData = "medicalHistoryInfoData";
            BaseActionResponse<MedicalHistoryInfo> response = new();
            var watch = Stopwatch.StartNew();
            try
            {
                var isValidMedicalHistory = _medicalHistoriesValid.ValidAddOrUpdate(inputModel, true);
                if (isValidMedicalHistory.Status != EnumStatus.success)
                    response = response.CreateResponse(isValidMedicalHistory, medicalHistoryInfoData);
                else
                {
                    var medicalHistoryData = await _medicalHistoriesServices.AddOrUpdate(inputModel, true);
                    response = response.CreateResponse(medicalHistoryData, medicalHistoryInfoData);
                }
            }
            catch (Exception ex)
            {
                response = response.CreateResponseCatch(medicalHistoryInfoData);
                _logger.LogError(ex, ex.Message);
            }
            finally
            {
                watch.Stop();
                response[nameof(response.executionTimeMilliseconds)] = watch.ElapsedMilliseconds;
            }
            return Ok(response);
        }

        [HttpPost("DeleteMedicalHistory")]
        public async Task<IActionResult> DeleteMedicalHistory([FromQuery] BaseDeleteDto inputModel)
        {
            BaseActionResponse<MedicalHistoryInfo> response = new();
            var watch = Stopwatch.StartNew();
            try
            {
                var isValidMedicalHistory = _medicalHistoriesValid.ValidDelete(inputModel);
                if (isValidMedicalHistory.Status != EnumStatus.success)
                {
                    response = response.CreateResponse(isValidMedicalHistory, medicalHistoryInfoData);
                }
                else
                {
                    var deletedMedicalHistory = await _medicalHistoriesServices.DeleteAsync(inputModel);
                    response = response.CreateResponse(deletedMedicalHistory, medicalHistoryInfoData);
                }
            }
            catch (Exception ex)
            {
                response = response.CreateResponseCatch(medicalHistoryInfoData);
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