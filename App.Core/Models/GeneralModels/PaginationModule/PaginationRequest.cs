namespace App.Core.Models.General.PaginationModule
{
    public class PaginationRequest
    {
        //TODO: Change General Operation At PaginationRequest  to BaseRequstModules
        public long pageSize { get; set; }

        public long page { get; set; }
    }
}