namespace ZenturyLoginsApp.Common.Extensions
{
    public static class PagingExtension
    {
        public static void ValidatePagingCriteria(this Paging paging)
        {
            if (paging != null)
            {
                if (paging.Page <= 0)
                    throw new ArgumentException("Page is not valid.");

                if (paging.RecordsPerPage <= 0)
                    throw new ArgumentException("Records per page value is not valid.");
            }
        }

        public static void ValidatePagingResults(this Paging paging)
        {
            if (paging != null && paging.Page > paging.Pages)
                throw new ArgumentException("Page is not valid.");
        }
    }
}
