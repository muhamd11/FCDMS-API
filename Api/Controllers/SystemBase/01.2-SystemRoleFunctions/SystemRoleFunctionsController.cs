using Api.Controllers.SystemBase.LogActions.Interfaces;
using Api.Controllers.UsersModules._01._2_UserAuthentications._0._2_Filters;
using App.Core.Consts.GeneralModels;
using App.Core.Models.SystemBase._01._2_SystemRoleFunctions;
using App.Core.Models.SystemBase._01._2_SystemRoleFunctions.DTO;
using App.Core.Models.SystemBase._01._2_SystemRoleFunctions.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Api.Controllers.SystemBase.SystemRoleFunctions
{
    [Route("api/[controller]")]
    [ApiController]
    [Authenticate]
    public class SystemRoleFunctionsController : ControllerBase
    {
        #region Members

        //services
        private readonly ILogger<SystemRoleFunctionsController> _logger;

        private readonly ISystemRoleFunctionsValid _systemRoleFunctionsValid;
        private readonly ISystemRoleFunctionsService _systemRoleFunctionsService;
        private readonly string systemRoleFunctionInfoDetails = "systemRoleFunctionInfoDetails";

        #endregion Members

        #region Constructor

        public SystemRoleFunctionsController(ISystemRoleFunctionsValid systemRoleFunctionsValid, ISystemRoleFunctionsService systemRoleFunctionsService, ILogger<SystemRoleFunctionsController> logger)
        {
            _logger = logger;
            _systemRoleFunctionsValid = systemRoleFunctionsValid;
            _systemRoleFunctionsService = systemRoleFunctionsService;
        }

        #endregion Constructor

        #region Methods

        [HttpGet("GetSystemRoleFunctionDetails")]
        public async Task<IActionResult> GetSystemRoleFincationDetails([FromQuery] Guid systemRoleToken)
        {
            BaseGetDetailsResponse<List<SystemRoleFunctionInfo>> response = new();
            var watch = Stopwatch.StartNew();
            try
            {
                var isValidSystemRoleFunction = _systemRoleFunctionsValid.ValidGetDetails(systemRoleToken);
                if (isValidSystemRoleFunction.Status != EnumStatus.success)
                    response = response.CreateResponse(isValidSystemRoleFunction, systemRoleFunctionInfoDetails);
                else
                {
                    var systemRoleFunctionDetails = await _systemRoleFunctionsService.GetDetails(systemRoleToken);
                    response = response.CreateResponse(systemRoleFunctionDetails, systemRoleFunctionInfoDetails);
                }
            }
            catch (Exception ex)
            {
                response = response.CreateResponseCatch(systemRoleFunctionInfoDetails);
                _logger.LogError(ex, ex.Message);
            }
            finally
            {
                watch.Stop();
                response[nameof(response.executionTimeMilliseconds)] = watch.ElapsedMilliseconds;
            }
            return Ok(response);
        }

        [HttpPost("UpdatePrivilege")]
        public async Task<IActionResult> UpdatePrivlage([FromBody] SystemRoleFunctionDto inputModel)
        {
            string systemRoleFunctionInfoData = "systemRoleFincationInfoData";
            BaseActionResponse<List<SystemRoleFunction>> response = new();
            var watch = Stopwatch.StartNew();
            try
            {
                var isValidSystemRoleFunction = _systemRoleFunctionsValid.ValidUpdatePrivilege(inputModel);
                if (isValidSystemRoleFunction.Status != EnumStatus.success)
                    response = response.CreateResponse(isValidSystemRoleFunction, systemRoleFunctionInfoData);
                else
                {
                    var systemRoleFincationData = await _systemRoleFunctionsService.UpdatePrivilege(inputModel);
                    response = response.CreateResponse(systemRoleFincationData, systemRoleFunctionInfoData);
                }
            }
            catch (Exception ex)
            {
                response = response.CreateResponseCatch(systemRoleFunctionInfoData);
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