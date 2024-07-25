using Microsoft.AspNetCore.Mvc;

namespace App.Core.Models.GeneralModels.BaseRequestHeaderModules
{
    public class BaseRequestHeaders
    {
        [FromHeader]
        public string userAuthorizeToken { get; set; }
    }
}