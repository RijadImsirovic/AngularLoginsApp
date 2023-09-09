using ZenturyLoginsApp.Common;

namespace ZenturyLoginsApp.Models.DTOs
{
    public class SearchResponse<T> where T : class
    {
        public List<T> Results { get; set; }
        public Paging Paging { get; set; }
    }
}
