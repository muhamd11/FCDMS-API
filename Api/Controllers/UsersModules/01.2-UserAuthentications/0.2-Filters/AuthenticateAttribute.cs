using App.Core;
using App.Core.Consts.GeneralModels;
using App.Core.Helper.Json;
using App.Core.Models.General.LocalModels;
using App.Core.Models.GeneralModels.AuthenticationModules;
using App.Core.Resources.UsersModules.User;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace Api.Controllers.UsersModules._01._2_UserAuthentications._0._2_Filters
{
    public class AuthenticateAttribute : ActionFilterAttribute, IFilterFactory
    {
        private readonly string _userAuthorizeToken = "userAuthorizeToken";

        private AuthenticationRespone response = new();

        public IUnitOfWork _unitOfWork { get; set; }

        public bool IsReusable => false;

        public IFilterMetadata CreateInstance(IServiceProvider serviceProvider)
        {
            var unitOfWork = serviceProvider.GetService<IUnitOfWork>();
            return new AuthenticateAttribute(unitOfWork);
        }

        public AuthenticateAttribute()
        {
        }

        public AuthenticateAttribute(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public override async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var watch = Stopwatch.StartNew();

            if (!context.HttpContext.Request.Headers.TryGetValue(_userAuthorizeToken, out var userAuthorizeToken))
            {
                var baseValid = BaseValid.createBaseValid(UsersMessagesAr.errorUserAuthorizeTokenNotFound, EnumStatus.error);
                response = response.CreateResponse(baseValid);
                watch.Stop();
                response[nameof(response.executionTimeMilliseconds)] = watch.ElapsedMilliseconds;
                context.Result = new OkObjectResult(response);
                return;
            };

            var userAuthorize = JsonConversion.DeserializeUserAuthorizeToken(userAuthorizeToken);

            var user = await _unitOfWork.Users.AsQueryable().AnyAsync(x => x.userToken == userAuthorize.userToken);

            if (!user)
            {
                response = response.CreateResponse(false);
                watch.Stop();
                response[nameof(response.executionTimeMilliseconds)] = watch.ElapsedMilliseconds;
                context.Result = new OkObjectResult(response);
                return;
            }

            await next();
        }
    }
}