using Api.Controllers.SystemBase.LogActions.Interfaces;
using App.Core.Consts.GeneralModels;
using App.Core.Interfaces.UsersModule.UserAuthentications;
using App.Core.Models.ClinicModules.VisitsModules;
using App.Core.Models.GeneralModels.BaseRequestHeaderModules;
using App.Core.Models.SystemBase._01._2_SystemRoleFunctions;
using App.Core.Models.SystemBase._01._2_SystemRoleFunctions.DTO;
using App.Core.Models.SystemBase._01._2_SystemRoleFunctions.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Api.Controllers.SystemBase.SystemRoleFunctions
{
    [Route("api/[controller]")]
    [ApiController]
    public class SystemRoleFunctionsController : ControllerBase
    {
        #region Members

        //services
        private readonly ILogger<SystemRoleFunctionsController> _logger;

        private readonly ISystemRoleFunctionsValid _systemRoleFunctionsValid;
        private readonly ISystemRoleFunctionsService _systemRoleFunctionsService;
        private readonly IUserAuthValid _userAuthValid;
        private readonly string systemRoleFunctionInfoDetails = "systemRoleFunctionInfoDetails";

        #endregion Members

        #region Constructor

        public SystemRoleFunctionsController(ISystemRoleFunctionsValid systemRoleFunctionsValid, ISystemRoleFunctionsService systemRoleFunctionsService, ILogger<SystemRoleFunctionsController> logger, IUserAuthValid userAuthValid)
        {
            _logger = logger;
            _systemRoleFunctionsValid = systemRoleFunctionsValid;
            _systemRoleFunctionsService = systemRoleFunctionsService;
            _userAuthValid = userAuthValid;
        }

        #endregion Constructor

        #region Methods

        [HttpGet("GetSystemRoleFunctionDetails")]
        public async Task<IActionResult> GetSystemRoleFincationDetails([FromQuery] Guid systemRoleToken, BaseRequestHeaders baseRequestHeaders)
        {
            BaseGetDetailsResponse<List<SystemRoleFunctionInfo>> response = new();
            var watch = Stopwatch.StartNew();
            try
            {
                var isAuthenticated = _userAuthValid.IsAuthenticated(baseRequestHeaders);
                if (isAuthenticated.Status != EnumStatus.success)
                    response = response.CreateResponse(isAuthenticated, systemRoleFunctionInfoDetails);
                else
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
        public async Task<IActionResult> UpdatePrivlage([FromBody] SystemRoleFunctionDto inputModel, BaseRequestHeaders baseRequestHeaders)
        {
            string systemRoleFunctionInfoData = "systemRoleFincationInfoData";
            BaseActionResponse<List<SystemRoleFunction>> response = new();
            var watch = Stopwatch.StartNew();
            try
            {
                var isAuthenticated = _userAuthValid.IsAuthenticated(baseRequestHeaders);
                if (isAuthenticated.Status != EnumStatus.success)
                    response = response.CreateResponse(isAuthenticated, systemRoleFunctionInfoDetails);
                else
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