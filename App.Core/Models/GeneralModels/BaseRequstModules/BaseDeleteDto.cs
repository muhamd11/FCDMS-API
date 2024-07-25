using Microsoft.AspNetCore.Mvc;

namespace App.Core.Models.General.BaseRequstModules
{
    public class BaseDeleteDto
    {
        [FromQuery] public Guid elementToken { get; set; }
    }
}