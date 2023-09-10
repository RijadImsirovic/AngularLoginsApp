using ZenturyLoginsApp.Models.DTOs;

namespace ZenturyLoginsApp.BLL.Interfaces
{
    public interface IApplicationUserService
    {
        Task<SearchResponse<UserDto>> SearchUsers(string query, int page, int pageSize, string sortColumn, string sortOrder);
    }
}
