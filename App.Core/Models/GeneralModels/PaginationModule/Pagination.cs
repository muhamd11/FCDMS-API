namespace App.Core.Models.General
{
    public class Pagination
    {
        public long totalPages { get; set; }
        public long totalItems { get; set; }
        public long countItemsInPage { get; set; }
        public long selfPage { get; set; }
        public long firstPage { get; set; }
        public long prevPage { get; set; }
        public long nextPage { get; set; }
        public long lastPage { get; set; }
    }
}