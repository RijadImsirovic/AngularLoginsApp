namespace ZenturyLoginsApp.Common
{
    public class Paging
    {
        public int Page { get; set; }
        public int TotalRecords { get; set; }
        public int RecordsPerPage { get; set; }

        public int Pages
        {
            get
            {
                var pages = 1;
                if (RecordsPerPage > 0)
                {
                    pages = (TotalRecords / RecordsPerPage) + (TotalRecords % RecordsPerPage > 0 ? 1 : 0);
                }

                return pages;
            }
        }
    }
}