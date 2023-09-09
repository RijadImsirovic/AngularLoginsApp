using Microsoft.EntityFrameworkCore;
using ZenturyLoginsApp.Common;
using ZenturyLoginsApp.Common.Extensions;
using ZenturyLoginsApp.DataServices.Data;
using ZenturyLoginsApp.DataServices.Repositories.Interfaces;
using ZenturyLoginsApp.Models.Entities;

namespace ZenturyLoginsApp.DataServices.Repositories
{
    public class LoginRepository : GenericRepository<Login>, ILoginRepository
    {
        public LoginRepository(AppDbContext context) : base(context)
        {
            
        }

        public async Task<IEnumerable<Login>> SearchLogins(string query, Paging paging)
        {
            query = !string.IsNullOrWhiteSpace(query) ? query.ToLower() : string.Empty;

            var logins = (await _table
                .Include(x => x.User)
                .Where(x => string.IsNullOrEmpty(query) || x.User.UserName.Contains(query) || x.User.Email.Contains(query))
                .ToListAsync())
                .GroupBy(x => x.Id)
                .Select(x => x.FirstOrDefault())
                .AsQueryable()
                .DoPaging(paging)
                .OrderByDescending(x => x.LoginAttemptAt);

            return logins;
        }
    }
}
