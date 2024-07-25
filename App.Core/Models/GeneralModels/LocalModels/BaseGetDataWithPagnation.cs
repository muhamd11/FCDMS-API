using System.Collections.Generic;

namespace App.Core.Models.General.LocalModels
{
    public class BaseGetDataWithPagnation<T>
    {
        public IEnumerable<T> Data { get; set; }
        public Pagination Pagination { get; set; }
    }
}