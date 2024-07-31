using App.Core.Consts.GeneralModels;
using App.Core.Interfaces.SystemBase.SystemRoles;
using App.Core.Interfaces.UsersModule.UserAuthentications;
using App.Core.Models.General.BaseRequstModules;
using App.Core.Models.GeneralModels.BaseRequestHeaderModules;
using App.Core.Models.SystemBase.Roles.DTO;
using App.Core.Models.SystemBase.Roles.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Api.Controllers.ClinicModules.SystemRoles
{
    [Route("api/[controller]")]
    [ApiController]
    public class SystemRolesController : ControllerBase
    {
        #region Members

        //services
        private readonly ILogger<SystemRolesController> _logger;

        private readonly ISystemRolesValid _systemRolesValid;
        private readonly ISystemRolesServices _systemRolesServices;
        private readonly IUserAuthValid _userAuthValid;

        //paramters
        private readonly string systemRoleInfoData = "systemRoleInfoData";

        private readonly string systemRolesInfoData = "systemRolesInfoData";
        private readonly string systemRoleInfoDetails = "systemRoleInfoDetails";

        #endregion Members

        #region Constructor

        public SystemRolesController(ISystemRolesValid systemRolesValid, ISystemRolesServices systemRolesServices, ILogger<SystemRolesController> logger, IUserAuthValid userAuthValid)
        {
            _logger = logger;
            _systemRolesValid = systemRolesValid;
            _systemRolesServices = systemRolesServices;
            _userAuthValid = userAuthValid;
        }

        #endregion Constructor

        #region Methods

        [HttpGet("GetSystemRoleDetails")]
        public async Task<IActionResult> GetSystemRoleDetails([FromQuery] BaseGetDetailsDto inputModel, BaseRequestHeaders baseRequestHeaders)
        {
            BaseGetDetailsResponse<SystemRoleInfoDetails> response = new();
            var watch = Stopwatch.StartNew();
            try
            {
                var isAuthenticated = _userAuthValid.IsAuthenticated(baseRequestHeaders);
                if (isAuthenticated.Status != EnumStatus.success)
                    response = response.CreateResponse(isAuthenticated, systemRoleInfoDetails);
                else
                {
                    var isValidSystemRole = _systemRolesValid.ValidGetDetails(inputModel);
                    if (isValidSystemRole.Status != EnumStatus.success)
                        response = response.CreateResponse(isValidSystemRole, systemRoleInfoDetails);
                    else
                    {
                        var systemRoleDetails = await _systemRolesServices.GetDetails(inputModel);
                        response = response.CreateResponse(systemRoleDetails, systemRoleInfoDetails);
                    }
                }
            }
            catch (Exception ex)
            {
                response = response.CreateResponseCatch(systemRoleInfoDetails);
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
        public async Task<IActionResult> GetAll([FromQuery] SystemRoleSearchDto inputModel, BaseRequestHeaders baseRequestHeaders)
        {
            BaseGetAllResponse<SystemRoleInfo> response = new();
            var watch = Stopwatch.StartNew();
            try
            {
                var isAuthenticated = _userAuthValid.IsAuthenticated(baseRequestHeaders);
                if (isAuthenticated.Status != EnumStatus.success)
                    response = response.CreateResponseError(isAuthenticated, systemRoleInfoDetails);
                else
                {
                    var isValidSystemRole = _systemRolesValid.ValidGetAll(inputModel);
                    if (isValidSystemRole.Status != EnumStatus.success)
                        response = response.CreateResponseError(isValidSystemRole, systemRolesInfoData);
                    else
                    {
                        var systemRole = await _systemRolesServices.GetAllAsync(inputModel);
                        response = response.CreateResponseSuccessOrNoContent(systemRole, systemRolesInfoData);
                    }
                }

            }
            catch (Exception ex)
            {
                response = response.CreateResponseCatch(systemRoleInfoData);
                _logger.LogError(ex, ex.Message);
            }
            finally
            {
                watch.Stop();
                response[nameof(response.executionTimeMilliseconds)] = watch.ElapsedMilliseconds;
            }
            return Ok(response);
        }

        [HttpPost("AddSystemRole")]
        public async Task<IActionResult> AddSystemRole([FromBody] SystemRoleAddOrUpdateDTO inputModel, BaseRequestHeaders baseRequestHeaders)
        {
            string systemRoleInfoData = "systemRoleInfoData";
            BaseActionResponse<SystemRoleInfo> response = new();
            var watch = Stopwatch.StartNew();
            try
            {
                var isAuthenticated = _userAuthValid.IsAuthenticated(baseRequestHeaders);
                if (isAuthenticated.Status != EnumStatus.success)
                    response = response.CreateResponse(isAuthenticated, systemRoleInfoDetails);
                else
                {
                    var isValidSystemRole = _systemRolesValid.ValidAddOrUpdate(inputModel, false);
                    if (isValidSystemRole.Status != EnumStatus.success)
                        response = response.CreateResponse(isValidSystemRole, systemRoleInfoData);
                    else
                    {
                        var systemRoleData = await _systemRolesServices.AddOrUpdate(inputModel, false);
                        response = response.CreateResponse(systemRoleData, systemRoleInfoData);
                    }
                }

            }
            catch (Exception ex)
            {
                response = response.CreateResponseCatch(systemRoleInfoData);
                _logger.LogError(ex, ex.Message);
            }
            finally
            {
                watch.Stop();
                response[nameof(response.executionTimeMilliseconds)] = watch.ElapsedMilliseconds;
            }
            return Ok(response);
        }

        [HttpPost("UpdateSystemRole")]
        public async Task<IActionResult> UpdateSystemRole([FromBody] SystemRoleAddOrUpdateDTO inputModel, BaseRequestHeaders baseRequestHeaders)
        {
            string systemRoleInfoData = "systemRoleInfoData";
            BaseActionResponse<SystemRoleInfo> response = new();
            var watch = Stopwatch.StartNew();
            try
            {
                var isAuthenticated = _userAuthValid.IsAuthenticated(baseRequestHeaders);
                if (isAuthenticated.Status != EnumStatus.success)
                    response = response.CreateResponse(isAuthenticated, systemRoleInfoDetails);
                else
                {
                    var isValidSystemRole = _systemRolesValid.ValidAddOrUpdate(inputModel, true);
                    if (isValidSystemRole.Status != EnumStatus.success)
                        response = response.CreateResponse(isValidSystemRole, systemRoleInfoData);
                    else
                    {
                        var systemRoleData = await _systemRolesServices.AddOrUpdate(inputModel, true);
                        response = response.CreateResponse(systemRoleData, systemRoleInfoData);
                    }
                }

            }
            catch (Exception ex)
            {
                response = response.CreateResponseCatch(systemRoleInfoData);
                _logger.LogError(ex, ex.Message);
            }
            finally
            {
                watch.Stop();
                response[nameof(response.executionTimeMilliseconds)] = watch.ElapsedMilliseconds;
            }
            return Ok(response);
        }

        [HttpPost("DeleteSystemRole")]
        public async Task<IActionResult> DeleteSystemRole([FromQuery] BaseDeleteDto inputModel, BaseRequestHeaders baseRequestHeaders)
        {
            BaseActionResponse<SystemRoleInfo> response = new();
            var watch = Stopwatch.StartNew();
            try
            {
                var isAuthenticated = _userAuthValid.IsAuthenticated(baseRequestHeaders);
                if (isAuthenticated.Status != EnumStatus.success)
                    response = response.CreateResponse(isAuthenticated, systemRoleInfoDetails);
                else
                {
                    var isValidSystemRole = _systemRolesValid.ValidDelete(inputModel);
                    if (isValidSystemRole.Status != EnumStatus.success)
                    {
                        response = response.CreateResponse(isValidSystemRole, systemRoleInfoData);
                    }
                    else
                    {
                        var deletedSystemRole = await _systemRolesServices.DeleteAsync(inputModel);
                        response = response.CreateResponse(deletedSystemRole, systemRoleInfoData);
                    }
                }
            }
            catch (Exception ex)
            {
                response = response.CreateResponseCatch(systemRoleInfoData);
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