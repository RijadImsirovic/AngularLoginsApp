using AutoMapper;
using ZenturyLoginsApp.BLL.Interfaces;
using ZenturyLoginsApp.Common;
using ZenturyLoginsApp.Common.Extensions;
using ZenturyLoginsApp.DataServices.Repositories.Interfaces;
using ZenturyLoginsApp.Models.DTOs;

namespace ZenturyLoginsApp.BLL
{
    public class LoginService : ILoginsService
    {
        private readonly ILoginRepository _loginRepository;
        private readonly IMapper _mapper;

        public LoginService(ILoginRepository loginRepository, IMapper mapper)
        {
            _loginRepository = loginRepository;
            _mapper = mapper;
        }

        public async Task<SearchResponse<LoginDto>> SearchLogins(string query, int page, int pageSize, string sortColumn, string sortOrder)
        {
            Paging paging = ValidatePagingAndFilterCriteria(query, page, pageSize);

            Sorting sorting = new Sorting
            {
                SortColumn = sortColumn,
                SortOrder = sortOrder
            };
            
            var logins = await _loginRepository.SearchLogins(query, paging, sorting);

            if (logins == null || paging.TotalRecords == 0)
                throw new FileNotFoundException("Logins could not be found.");

            paging.ValidatePagingResults();

            var mappedLogins = _mapper.Map<List<LoginDto>>(logins);

            return new SearchResponse<LoginDto>
            {
                Results = mappedLogins,
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
    }
}
