using App.Core.Consts.GeneralModels;
using App.Core.Interfaces.UsersModule.UserAuthentications;
using App.Core.Models.General.LocalModels;
using App.Core.Models.Users;
using App.Core.Models.UsersModule._01._2_UserAuthentications.LoginModule.DTO;
using App.Core.Models.UsersModule._01._2_UserAuthentications.LoginModule.ViewModel;
using App.Core.Models.UsersModule._01._2_UserAuthentications.SignUpModule.DTO;
using App.Core.Resources.UsersModules.User;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Api.Controllers.UsersModules._01._2_UserAuthentications._01._0_UsersLogin
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserAuthenticationController : ControllerBase
    {
        #region Members

        private readonly IUserAuthenticationValid _usersAuthValid;
        private readonly IUserAuthenticationServices _userAuthServices;
        private readonly ILogger<UserAuthenticationController> _logger;
        private readonly string userLoginInfo = "userLoginInfo";
        private readonly string userSignupInfo = "userSignupInfo";

        #endregion Members

        #region Constructor

        public UserAuthenticationController(IUserAuthenticationServices userAuthServices, IUserAuthenticationValid usersAuthValid, ILogger<UserAuthenticationController> logger)
        {
            _userAuthServices = userAuthServices;
            _usersAuthValid = usersAuthValid;
            _logger = logger;
        }

        #endregion Constructor

        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] UserLoginDto inputModel)
        {
            BaseGetDetailsResponse<UserLoginInfo> response = new();
            var watch = Stopwatch.StartNew();
            try
            {
                var isValidLogin = _usersAuthValid.IsValidLogin(inputModel);
                if (isValidLogin.Status != EnumStatus.success)
                    response = response.CreateResponse(isValidLogin, userLoginInfo);
                else
                {
                    var userInfo = await _userAuthServices.Login(inputModel);
                    if (userInfo != null)
                        response = response.CreateResponse(userInfo, userLoginInfo);
                    else
                        response = response.CreateResponse(BaseValid.createBaseValidError(UsersMessagesAr.errorInvalidUserLoginData), userLoginInfo);
                }
            }
            catch (Exception ex)
            {
                response = response.CreateResponseCatch(userLoginInfo);
                _logger.LogError(ex, ex.Message);
            }
            finally
            {
                watch.Stop();
                response[nameof(response.executionTimeMilliseconds)] = watch.ElapsedMilliseconds;
            }
            return Ok(response);
        }

        [HttpPost("Signup")]
        public async Task<IActionResult> Signup([FromBody] UserSignUpDto inputModel)
        {
            BaseGetDetailsResponse<UserInfo> response = new();
            var watch = Stopwatch.StartNew();
            try
            {
                var isValidSignUp = _usersAuthValid.IsValidSignUp(inputModel);
                if (isValidSignUp.Status != EnumStatus.success)
                    response = response.CreateResponse(isValidSignUp, userSignupInfo);
                else
                {
                    var userInfo = await _userAuthServices.Signup(inputModel);
                    response = response.CreateResponse(userInfo, userSignupInfo);
                }
            }
            catch (Exception ex)
            {
                response = response.CreateResponseCatch(userSignupInfo);
                _logger.LogError(ex, ex.Message);
            }
            finally
            {
                watch.Stop();
                response[nameof(response.executionTimeMilliseconds)] = watch.ElapsedMilliseconds;
            }
            return Ok(response);
        }
    }
}