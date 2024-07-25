using App.Core.Consts.GeneralModels;
using App.Core.Interfaces.SystemBase.SystemRoles;
using App.Core.Models.General.BaseRequstModules;
using App.Core.Models.SystemBase.Roles.DTO;
using App.Core.Models.SystemBase.Roles.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Api.Controllers.SystemBase.SystemRoles
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

        //paramters
        private readonly string systemRoleInfoData = "systemRoleInfoData";

        private readonly string systemRolesInfoData = "systemRolesInfoData";
        private readonly string systemRoleInfoDetails = "systemRoleInfoDetails";

        #endregion Members

        #region Constructor

        public SystemRolesController(ISystemRolesValid systemRolesValid, ISystemRolesServices systemRolesServices, ILogger<SystemRolesController> logger)
        {
            _logger = logger;
            _systemRolesValid = systemRolesValid;
            _systemRolesServices = systemRolesServices;
        }

        #endregion Constructor

        #region Methods

        [HttpGet("GetSystemRoleDetails")]
        public async Task<IActionResult> GetSystemRoleDetails([FromQuery] BaseGetDetailsDto inputModel)
        {
            BaseGetDetailsResponse<SystemRoleInfoDetails> response = new();
            var watch = Stopwatch.StartNew();
            try
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
            catch (Exception ex)
            {
                response = response.CreateResponseCatch(systemRoleInfoDetails);
                _logger.LogError(ex, ex.Message);
            }
            finally
            {
                watch.Stop();
                response["ExecutionTimeMilliseconds"] = watch.ElapsedMilliseconds;
            }
            return Ok(response);
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll([FromQuery] SystemRoleSearchDto inputModel)
        {
            BaseGetAllResponse<SystemRoleInfo> response = new();
            var watch = Stopwatch.StartNew();
            try
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
            catch (Exception ex)
            {
                response = response.CreateResponseCatch(systemRoleInfoData);
                _logger.LogError(ex, ex.Message);
            }
            finally
            {
                watch.Stop();
                response["ExecutionTimeMilliseconds"] = watch.ElapsedMilliseconds;
            }
            return Ok(response);
        }

        [HttpPost("AddSystemRole")]
        public async Task<IActionResult> AddSystemRole([FromBody] SystemRoleAddOrUpdateDTO inputModel)
        {
            string systemRoleInfoData = "systemRoleInfoData";
            BaseActionResponse<SystemRoleInfo> response = new();
            var watch = Stopwatch.StartNew();
            try
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
            catch (Exception ex)
            {
                response = response.CreateResponseCatch(systemRoleInfoData);
                _logger.LogError(ex, ex.Message);
            }
            finally
            {
                watch.Stop();
                response["ExecutionTimeMilliseconds"] = watch.ElapsedMilliseconds;
            }
            return Ok(response);
        }

        [HttpPost("UpdateSystemRole")]
        public async Task<IActionResult> UpdateSystemRole([FromBody] SystemRoleAddOrUpdateDTO inputModel)
        {
            string systemRoleInfoData = "systemRoleInfoData";
            BaseActionResponse<SystemRoleInfo> response = new();
            var watch = Stopwatch.StartNew();
            try
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
            catch (Exception ex)
            {
                response = response.CreateResponseCatch(systemRoleInfoData);
                _logger.LogError(ex, ex.Message);
            }
            finally
            {
                watch.Stop();
                response["ExecutionTimeMilliseconds"] = watch.ElapsedMilliseconds;
            }
            return Ok(response);
        }

        [HttpPost("DeleteSystemRole")]
        public async Task<IActionResult> DeleteSystemRole([FromQuery] BaseDeleteDto inputModel)
        {
            BaseActionResponse<SystemRoleInfo> response = new();
            var watch = Stopwatch.StartNew();
            try
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
            catch (Exception ex)
            {
                response = response.CreateResponseCatch(systemRoleInfoData);
                _logger.LogError(ex, ex.Message);
            }
            finally
            {
                watch.Stop();
                response["ExecutionTimeMilliseconds"] = watch.ElapsedMilliseconds;
            }
            return Ok(response);
        }

        #endregion Methods
    }
}