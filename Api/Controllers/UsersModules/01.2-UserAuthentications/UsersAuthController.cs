using App.Core.Consts.GeneralModels;
using App.Core.Interfaces.UsersModule.UsersAuthentications;
using App.Core.Interfaces.UsersModule.UsersAuthentications.UsersLogin;
using App.Core.Models.UsersModule._01._2_UserAuthentications.LoginModule.DTO;
using App.Core.Models.UsersModule._01._2_UserAuthentications.LoginModule.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Api.Controllers.UsersModules._01._2_UserAuthentications._01._0_UsersLogin
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersAuthController : ControllerBase
    {
        private readonly IUserAuthServices _userAuthServices;

        #region Members

        private readonly IUsersLoginValid _usersLoginValid;
        private readonly ILogger<UsersAuthController> _logger;
        private readonly string userLoginInfo = "userLoginInfo";

        #endregion Members

        #region Constructor

        public UsersAuthController(IUserAuthServices userAuthServices, IUsersLoginValid usersLoginValid, ILogger<UsersAuthController> logger)
        {
            _userAuthServices = userAuthServices;
            _usersLoginValid = usersLoginValid;
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
                response["ExecutionTimeMilliseconds"] = watch.ElapsedMilliseconds;
            }
            return Ok(response);
        }
    }
}