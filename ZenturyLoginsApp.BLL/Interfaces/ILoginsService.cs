using ZenturyLoginsApp.Models.DTOs;

namespace ZenturyLoginsApp.BLL.Interfaces
{
    public interface ILoginsService
    {
        Task<SearchResponse<LoginDto>> SearchLogins(string query, int page, int pageSize);
    }
}
