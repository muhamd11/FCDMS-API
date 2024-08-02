using App.Core.Consts.GeneralModels;
using App.Core.Interfaces.UsersModule.UserAuthentications;
using App.Core.Interfaces.UsersModule.UserAuthentications.UsersLogin;
using App.Core.Interfaces.UsersModule.UserAuthentications.UsersSignUp;
using App.Core.Models.UsersModule._01._2_UserAuthentications.LoginModule.DTO;
using App.Core.Models.UsersModule._01._2_UserAuthentications.LoginModule.ViewModel;
using App.Core.Models.UsersModule._01._2_UserAuthentications.SignUpModule.DTO;
using App.Core.Models.UsersModule._01._2_UserAuthentications.SignUpModule.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Api.Controllers.UsersModules._01._2_UserAuthentications._01._0_UsersLogin
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersAuthController : ControllerBase
    {
        #region Members

        private readonly IUserAuthServices _userAuthServices;
        private readonly IUsersLoginValid _usersLoginValid;
        private readonly IUsersSignUpValid _usersSignUpValid;
        private readonly ILogger<UsersAuthController> _logger;
        private readonly string userLoginInfo = "userLoginInfo";
        private readonly string userSignupInfo = "userSignupInfo";

        #endregion Members

        #region Constructor

        public UsersAuthController(IUserAuthServices userAuthServices, IUsersLoginValid usersLoginValid, ILogger<UsersAuthController> logger, IUsersSignUpValid usersSignUpValid)
        {
            _userAuthServices = userAuthServices;
            _usersLoginValid = usersLoginValid;
            _logger = logger;
            _usersSignUpValid = usersSignUpValid;
        }

        #endregion Constructor

        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] UserLoginDto inputModel)
        {
            BaseGetDetailsResponse<UserLoginInfo> response = new();
            var watch = Stopwatch.StartNew();
            try
            {
                var isValidLogin = _usersLoginValid.IsValidLogin(inputModel);
                if (isValidLogin.Status != EnumStatus.success)
                    response = response.CreateResponse(isValidLogin, userLoginInfo);
                else
                {
                    var userInfo = await _userAuthServices.Login(inputModel);
                    response = response.CreateResponse(userInfo, userLoginInfo);
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
            BaseGetDetailsResponse<UserSignUpInfo> response = new();
            var watch = Stopwatch.StartNew();
            try
            {
                var isValidSignUp = _usersSignUpValid.IsValidSignUp(inputModel);
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