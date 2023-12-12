using System.ComponentModel;

namespace Project.Common
{
    public class QueryParameters
    {
        public string? FilterByName { get; set; }

        public string? SortBy { get; set; }

        public bool? IsAscending { get; set; } = true;

        public int PageNumber { get; set; } = 1;

        public int PageSize { get; set; } = 1000;



    }
}