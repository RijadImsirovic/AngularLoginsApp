using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using ZenturyLoginsApp.BLL.Interfaces;
using ZenturyLoginsApp.Common;
using ZenturyLoginsApp.Common.Extensions;
using ZenturyLoginsApp.Models.DTOs;
using ZenturyLoginsApp.Models.Entities;

namespace ZenturyLoginsApp.BLL
{
    public class ApplicationUserService : IApplicationUserService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IMapper _mapper;

        public ApplicationUserService(UserManager<ApplicationUser> userManager, IMapper mapper)
        {
            _userManager = userManager;
            _mapper = mapper;
        }

        public async Task<SearchResponse<UserDto>> SearchUsers(string query, int page, int pageSize, string sortColumn, string sortOrder)
        {
            Paging paging = ValidatePagingAndFilterCriteria(query, page, pageSize);

            Sorting sorting = new Sorting
            {
                SortColumn = sortColumn,
                SortOrder = sortOrder
            };

            var users = (await _userManager.Users
                .Where(x => string.IsNullOrEmpty(query) || x.UserName.Contains(query) || x.Email.Contains(query))
                .ToListAsync())
                .GroupBy(x => x.Id)
                .Select(x => x.FirstOrDefault())
                .AsQueryable()
                .DoPaging(paging);


            if (sorting.SortOrder?.ToLower() == "desc")
                users = users.OrderByDescending(GetSortProperty(sorting));
            else
                users = users.OrderBy(GetSortProperty(sorting));

            if (users == null || paging.TotalRecords == 0)
                throw new FileNotFoundException("Logins could not be found.");

            paging.ValidatePagingResults();

            var mappedUsers = _mapper.Map<List<UserDto>>(users);

            return new SearchResponse<UserDto>
            {
                Results = mappedUsers,
                Paging = paging
            };
        }

        private Paging ValidatePagingAndFilterCriteria(string query, int page, int pageSize)
        {
            var paging = new Paging
            {
                Page = page,
                RecordsPerPage = pageSize
            };

            paging.ValidatePagingCriteria();

            return paging;
        }

        private static Expression<Func<ApplicationUser?, object>> GetSortProperty(Sorting sorting)
        {
            return sorting.SortColumn?.ToLower() switch
            {
                "id" => user => user.Id,
                "username" => user => user.UserName,
                "email" => user => user.Email,
                _ => user => user.UserName
            };
        }
    }
}
