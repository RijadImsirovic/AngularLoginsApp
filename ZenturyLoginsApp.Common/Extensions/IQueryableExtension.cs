namespace ZenturyLoginsApp.Common.Extensions
{
    public static class IQueryableExtension
    {
        public static IQueryable<T> DoPaging<T>(this IQueryable<T> source, Paging paging)
        {
            if (paging == null)
                return source;

            if (source == null)
                throw new ArgumentNullException("source");

            paging.TotalRecords = source.Count();

            int takeElements = paging.RecordsPerPage;
            int skipElements = paging.Page > 0 ? (paging.Page - 1) * paging.RecordsPerPage : 0;

            return source is IOrderedQueryable ?
                source.Skip(skipElements).Take(takeElements) :
                source.OrderBy(p => 0).Skip(skipElements).Take(takeElements);
        }
    }
}
