using App.Core.Helper.Json;
using App.Core.Helper.Validations;
using App.Core.Interfaces.GeneralInterfaces;

namespace Api.Controllers.GeneralServices
{
    public class HeaderRequestServices(IHttpContextAccessor httpContextAccessor) : IHeaderRequest
    {
        private readonly IHttpContextAccessor _httpContextAccessor = httpContextAccessor;

        public Guid? GetUserToken()
        {
            var userAuthorizeToken = GetUserAuthorizeToken();
            if (!ValidationClass.IsValidString(userAuthorizeToken))
                return null;
            else
            {
                var userAuthorize = JsonConversion.DeserializeUserAuthorizeToken(userAuthorizeToken!);
                return userAuthorize.userToken;
            }
        }

        private string? GetUserAuthorizeToken() => _httpContextAccessor?.HttpContext?.Request.Headers["userAuthorizeToken"].FirstOrDefault();
    }
}