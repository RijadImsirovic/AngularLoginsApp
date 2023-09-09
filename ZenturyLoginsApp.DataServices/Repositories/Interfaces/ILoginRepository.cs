using ZenturyLoginsApp.Common;
using ZenturyLoginsApp.Models.Entities;

namespace ZenturyLoginsApp.DataServices.Repositories.Interfaces
{
    public interface ILoginRepository : IGenericRepository<Login>
    {
        Task<IEnumerable<Login>> SearchLogins(string query, Paging paging, Sorting sorting);
    }
}
