using App.Core.Helper.Json;
using App.Core.Models.UsersModule._01._2_UserAuthentications.LoginModule;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace App.Core.Models.GeneralModels.BaseRequstModules
{
    public class GeneralOperation
    {
        [FromHeader(Name = "userAuthorizeToken")]
        public string userAuthorizeToken { get; set; }
    }
}
