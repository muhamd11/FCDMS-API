using App.Core;
using App.Core.Consts.GeneralModels;
using App.Core.Helper.Json;
using App.Core.Models.General.LocalModels;
using App.Core.Models.GeneralModels.AuthenticationModules;
using App.Core.Resources.UsersModules.User;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Diagnostics;

namespace Api.Controllers.UsersModules._01._2_UserAuthentications._0._2_Filters
{
    public class HasPermissionAttribute : ActionFilterAttribute, IFilterFactory
    {
        private readonly string _userAuthorizeToken = "userAuthorizeToken";
        private readonly string _functionId;
        private readonly IUnitOfWork _unitOfWork;

        private AuthenticationRespone response = new();

        public bool IsReusable => false;


        public HasPermissionAttribute(string functionId)
        {
            _functionId = functionId;
        }

        private HasPermissionAttribute(IUnitOfWork unitOfWork, string functionId)
        {
            _unitOfWork = unitOfWork;
            _functionId = functionId;
        }

        public IFilterMetadata CreateInstance(IServiceProvider serviceProvider)
        {
            var unitOfWork = serviceProvider.GetService<IUnitOfWork>();
            return new HasPermissionAttribute(unitOfWork, _functionId);
        }


        public override async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var watch = Stopwatch.StartNew();
            context.HttpContext.Request.Headers.TryGetValue(_userAuthorizeToken, out var userAuthorizeToken);

            var userAuthorize = JsonConversion.DeserializeUserAuthorizeToken(userAuthorizeToken);

            var isHasPermission = _unitOfWork.SystemRoleFunctions
                .Any(x => x.systemRoleToken == userAuthorize.systemRoleToken && x.functionId == _functionId && x.isHavePrivilege);


            if (!isHasPermission)
            {
                var baseValid = BaseValid.createBaseValid(UsersMessagesAr.errorHasNoPermission, EnumStatus.error);
                response = response.CreateResponse(baseValid);
                watch.Stop();
                response[nameof(response.executionTimeMilliseconds)] = watch.ElapsedMilliseconds;
                context.Result = new OkObjectResult(response);
                return;
            }
             await next();
        }
    }
}
