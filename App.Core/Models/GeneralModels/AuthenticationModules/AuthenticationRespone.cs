using App.Core.Consts.GeneralModels;
using App.Core.Models.General.LocalModels;
using App.Core.Resources.General;
using App.Core.Resources.UsersModules.User;


namespace App.Core.Models.GeneralModels.AuthenticationModules
{
    public class AuthenticationRespone :  Dictionary<string, object>
    {
        public EnumStatus status { get; set; }
        public string msg { get; set; }
        public decimal executionTimeMilliseconds { get; set; }


        public AuthenticationRespone CreateResponse(bool isAuthenticated)
        {
            var response = new AuthenticationRespone
            {
                msg = isAuthenticated ? GeneralMessagesAr.actionSuccess : UsersMessagesAr.errorUserDoesNotExists,
                status = isAuthenticated ? EnumStatus.success : EnumStatus.error,
            };

            response[nameof(status)] = response.status;
            response[nameof(msg)] = response.msg;
            response[nameof(executionTimeMilliseconds)] = response.executionTimeMilliseconds;

            return response;
        }

        public AuthenticationRespone CreateResponse(BaseValid baseValid)
        {
            var response = new AuthenticationRespone
            {
                msg = baseValid.Message,
                status = baseValid.Status,
            };
            response[nameof(status)] = response.status;
            response[nameof(msg)] = response.msg;
            response[nameof(executionTimeMilliseconds)] = response.executionTimeMilliseconds;


            return response;
        }
    }
}
