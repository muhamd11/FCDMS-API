using Api.Controllers.UsersModules.Users.Interfaces;
using App.Core.Consts.GeneralModels;
using App.Core.Interfaces.UsersModule.Users;
using App.Core.Models.General.BaseRequstModules;
using App.Core.Models.Users;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Api.Controllers.ClinicModules.Users
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        #region Members

        //services
        private readonly ILogger<UsersController> _logger;

        private readonly IUsersValid _usersValid;
        private readonly IUsersServices _usersServices;

        //paramters
        private readonly string userInfoData = "userInfoData";

        private readonly string usersInfoData = "usersInfoData";
        private readonly string userInfoDetails = "userInfoDetails";

        #endregion Members

        #region Constructor

        public UsersController(IUsersValid usersValid, IUsersServices usersServices, ILogger<UsersController> logger)
        {
            _logger = logger;
            _usersValid = usersValid;
            _usersServices = usersServices;
        }

        #endregion Constructor

        #region Methods

        [HttpGet("GetUserDetails")]
        public async Task<IActionResult> GetUserDetails([FromQuery] BaseGetDetailsDto inputModel)
        {
            BaseGetDetailsResponse<UserInfoDetails> response = new();
            var watch = Stopwatch.StartNew();
            try
            {
                var isValidUser = _usersValid.ValidGetDetails(inputModel);
                if (isValidUser.Status != EnumStatus.success)
                    response = response.CreateResponse(isValidUser, userInfoDetails);
                else
                {
                    var userDetails = await _usersServices.GetDetails(inputModel);
                    response = response.CreateResponse(userDetails, userInfoDetails);
                }
            }
            catch (Exception ex)
            {
                response = response.CreateResponseCatch(userInfoDetails);
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
        public async Task<IActionResult> GetAll([FromQuery] UserSearchDto inputModel)
        {
            BaseGetAllResponse<UserInfo> response = new();
            var watch = Stopwatch.StartNew();
            try
            {
                var isValidUser = _usersValid.ValidGetAll(inputModel);
                if (isValidUser.Status != EnumStatus.success)
                    response = response.CreateResponseError(isValidUser, usersInfoData);
                else
                {
                    var user = await _usersServices.GetAllAsync(inputModel);
                    response = response.CreateResponseSuccessOrNoContent(user, usersInfoData);
                }
            }
            catch (Exception ex)
            {
                response = response.CreateResponseCatch(userInfoData);
                _logger.LogError(ex, ex.Message);
            }
            finally
            {
                watch.Stop();
                response[nameof(response.executionTimeMilliseconds)] = watch.ElapsedMilliseconds;
            }
            return Ok(response);
        }

        [HttpPost("AddUser")]
        public async Task<IActionResult> AddUser([FromBody] UserAddOrUpdateDTO inputModel)
        {
            string userInfoData = "userInfoData";
            BaseActionResponse<UserInfo> response = new();
            var watch = Stopwatch.StartNew();
            try
            {
                var isValidUser = _usersValid.ValidAddOrUpdate(inputModel, false);
                if (isValidUser.Status != EnumStatus.success)
                    response = response.CreateResponse(isValidUser, userInfoData);
                else
                {
                    var userData = await _usersServices.AddOrUpdate(inputModel, false);
                    response = response.CreateResponse(userData, userInfoData);
                }
            }
            catch (Exception ex)
            {
                response = response.CreateResponseCatch(userInfoData);
                _logger.LogError(ex, ex.Message);
            }
            finally
            {
                watch.Stop();
                response[nameof(response.executionTimeMilliseconds)] = watch.ElapsedMilliseconds;
            }
            return Ok(response);
        }

        [HttpPost("UpdateUser")]
        public async Task<IActionResult> UpdateUser([FromBody] UserAddOrUpdateDTO inputModel)
        {
            string userInfoData = "userInfoData";
            BaseActionResponse<UserInfo> response = new();
            var watch = Stopwatch.StartNew();
            try
            {
                var isValidUser = _usersValid.ValidAddOrUpdate(inputModel, true);
                if (isValidUser.Status != EnumStatus.success)
                    response = response.CreateResponse(isValidUser, userInfoData);
                else
                {
                    var userData = await _usersServices.AddOrUpdate(inputModel, true);
                    response = response.CreateResponse(userData, userInfoData);
                }
            }
            catch (Exception ex)
            {
                response = response.CreateResponseCatch(userInfoData);
                _logger.LogError(ex, ex.Message);
            }
            finally
            {
                watch.Stop();
                response[nameof(response.executionTimeMilliseconds)] = watch.ElapsedMilliseconds;
            }
            return Ok(response);
        }

        [HttpPost("DeleteUser")]
        public async Task<IActionResult> DeleteUser([FromQuery] BaseDeleteDto inputModel)
        {
            BaseActionResponse<UserInfo> response = new();
            var watch = Stopwatch.StartNew();
            try
            {
                var isValidUser = _usersValid.ValidDelete(inputModel);
                if (isValidUser.Status != EnumStatus.success)
                {
                    response = response.CreateResponse(isValidUser, userInfoData);
                }
                else
                {
                    var deletedUser = await _usersServices.DeleteAsync(inputModel);
                    response = response.CreateResponse(deletedUser, userInfoData);
                }
            }
            catch (Exception ex)
            {
                response = response.CreateResponseCatch(userInfoData);
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