using App.Core.Models.GeneralModels.BaseRequestHeaderModules;
using Microsoft.AspNetCore.Mvc;

namespace App.Core.Models.General.BaseRequstModules
{
    public class BaseDeleteDto 
    {
        public Guid elementToken { get; set; }
    }
}