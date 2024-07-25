using App.Core.Models.General.PaginationModule;
using Microsoft.AspNetCore.Mvc;
using System;

namespace App.Core.Models.General.BaseRequstModules
{
    public class BaseSearchDto : PaginationRequest
    {
       [FromQuery] public Guid? elementToken { get; set; }
       [FromQuery] public string? textSearch { get; set; }
    }
}