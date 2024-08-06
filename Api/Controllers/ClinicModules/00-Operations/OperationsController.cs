using App.Core.Consts.GeneralModels;
using App.Core.Interfaces.SystemBase.Operations;
using App.Core.Models.ClinicModules.OperationsModules;
using App.Core.Models.ClinicModules.OperationsModules.DTO;
using App.Core.Models.General.BaseRequstModules;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Api.Controllers.ClinicModules.Operations
{
    [Route("api/[controller]")]
    [ApiController]
    public class OperationsController : ControllerBase
    {
        #region Members

        //services
        private readonly ILogger<OperationsController> _logger;

        private readonly IOperationsValid _operationsValid;
        private readonly IOperationsServices _operationsServices;

        //paramters
        private readonly string operationInfoData = "operationInfoData";

        private readonly string operationsInfoData = "operationsInfoData";
        private readonly string operationInfoDetails = "operationInfoDetails";

        #endregion Members

        #region Constructor

        public OperationsController(IOperationsValid operationsValid, IOperationsServices operationsServices, ILogger<OperationsController> logger)
        {
            _logger = logger;
            _operationsValid = operationsValid;
            _operationsServices = operationsServices;
        }

        #endregion Constructor

        #region Methods

        [HttpGet("GetOperationDetails")]
        public async Task<IActionResult> GetOperationDetails([FromQuery] OperationGetDetailsDTO inputModel)
        {
            BaseGetDetailsResponse<OperationInfoDetails> response = new();
            var watch = Stopwatch.StartNew();
            try
            {
                var isValidOperation = _operationsValid.ValidGetDetails(inputModel);
                if (isValidOperation.Status != EnumStatus.success)
                    response = response.CreateResponse(isValidOperation, operationInfoDetails);
                else
                {
                    var operationDetails = await _operationsServices.GetDetails(inputModel);
                    response = response.CreateResponse(operationDetails, operationInfoDetails);
                }
            }
            catch (Exception ex)
            {
                response = response.CreateResponseCatch(operationInfoDetails);
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
        public async Task<IActionResult> GetAll([FromQuery] OperationSearchDTO inputModel)
        {
            BaseGetAllResponse<OperationInfo> response = new();
            var watch = Stopwatch.StartNew();
            try
            {
                var isValidOperation = _operationsValid.ValidGetAll(inputModel);
                if (isValidOperation.Status != EnumStatus.success)
                    response = response.CreateResponseError(isValidOperation, operationsInfoData);
                else
                {
                    var operation = await _operationsServices.GetAllAsync(inputModel);
                    response = response.CreateResponseSuccessOrNoContent(operation, operationsInfoData);
                }
            }
            catch (Exception ex)
            {
                response = response.CreateResponseCatch(operationInfoData);
                _logger.LogError(ex, ex.Message);
            }
            finally
            {
                watch.Stop();
                response[nameof(response.executionTimeMilliseconds)] = watch.ElapsedMilliseconds;
            }
            return Ok(response);
        }

        [HttpPost("AddOperation")]
        public async Task<IActionResult> AddOperation([FromBody] OperationAddOrUpdateDTO inputModel)
        {
            string operationInfoData = "operationInfoData";
            BaseActionResponse<OperationInfo> response = new();
            var watch = Stopwatch.StartNew();
            try
            {
                var isValidOperation = _operationsValid.ValidAddOrUpdate(inputModel, false);
                if (isValidOperation.Status != EnumStatus.success)
                    response = response.CreateResponse(isValidOperation, operationInfoData);
                else
                {
                    var operationData = await _operationsServices.AddOrUpdate(inputModel, false);
                    response = response.CreateResponse(operationData, operationInfoData);
                }
            }
            catch (Exception ex)
            {
                response = response.CreateResponseCatch(operationInfoData);
                _logger.LogError(ex, ex.Message);
            }
            finally
            {
                watch.Stop();
                response[nameof(response.executionTimeMilliseconds)] = watch.ElapsedMilliseconds;
            }
            return Ok(response);
        }

        [HttpPost("UpdateOperation")]
        public async Task<IActionResult> UpdateOperation([FromBody] OperationAddOrUpdateDTO inputModel)
        {
            string operationInfoData = "operationInfoData";
            BaseActionResponse<OperationInfo> response = new();
            var watch = Stopwatch.StartNew();
            try
            {
                var isValidOperation = _operationsValid.ValidAddOrUpdate(inputModel, true);
                if (isValidOperation.Status != EnumStatus.success)
                    response = response.CreateResponse(isValidOperation, operationInfoData);
                else
                {
                    var operationData = await _operationsServices.AddOrUpdate(inputModel, true);
                    response = response.CreateResponse(operationData, operationInfoData);
                }
            }
            catch (Exception ex)
            {
                response = response.CreateResponseCatch(operationInfoData);
                _logger.LogError(ex, ex.Message);
            }
            finally
            {
                watch.Stop();
                response[nameof(response.executionTimeMilliseconds)] = watch.ElapsedMilliseconds;
            }
            return Ok(response);
        }

        [HttpPost("DeleteOperation")]
        public async Task<IActionResult> DeleteOperation([FromQuery] BaseDeleteDto inputModel)
        {
            BaseActionResponse<OperationInfo> response = new();
            var watch = Stopwatch.StartNew();
            try
            {
                var isValidOperation = _operationsValid.ValidDelete(inputModel);
                if (isValidOperation.Status != EnumStatus.success)
                {
                    response = response.CreateResponse(isValidOperation, operationInfoData);
                }
                else
                {
                    var deletedOperation = await _operationsServices.DeleteAsync(inputModel);
                    response = response.CreateResponse(deletedOperation, operationInfoData);
                }
            }
            catch (Exception ex)
            {
                response = response.CreateResponseCatch(operationInfoData);
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