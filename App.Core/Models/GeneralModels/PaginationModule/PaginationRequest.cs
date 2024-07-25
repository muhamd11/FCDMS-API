using App.Core.Models.GeneralModels.BaseRequstModules;
using Microsoft.AspNetCore.Mvc;
namespace App.Core.Models.General.PaginationModule
{
    public class PaginationRequest : GeneralOperation
    {
        //TODO: Change General Operation At PaginationRequest  to BaseRequstModules
        [FromQuery]  public long pageSize { get; set; }
        [FromQuery] public long page { get; set; }
    }
}