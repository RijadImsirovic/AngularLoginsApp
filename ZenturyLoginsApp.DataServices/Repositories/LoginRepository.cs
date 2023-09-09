using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
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

        public async Task<IEnumerable<Login>> SearchLogins(string query, Paging paging, Sorting sorting)
        {
            query = !string.IsNullOrWhiteSpace(query) ? query.ToLower() : string.Empty;

            var logins = (await _table
                .Include(x => x.User)
                .Where(x => string.IsNullOrEmpty(query) || x.User.UserName.Contains(query) || x.User.Email.Contains(query))
                .ToListAsync())
                .GroupBy(x => x.Id)
                .Select(x => x.FirstOrDefault())
                .AsQueryable()
                .DoPaging(paging);

            if (sorting.SortOrder?.ToLower() == "desc")
                logins = logins.OrderByDescending(GetSortProperty(sorting));
            else
                logins = logins.OrderBy(GetSortProperty(sorting));

            return logins;
        }

        private static Expression<Func<Login?, object>> GetSortProperty(Sorting sorting)
        {
            return sorting.SortColumn?.ToLower() switch
            {
                "id" => login => login.Id,
                "userid" => login => login.UserId,
                "username" => login => login.User.UserName,
                "email" => login => login.User.Email,
                "issuccessful" => login => login.IsSuccessful,
                _ => login => login.LoginAttemptAt
            };
        }
    }
}
