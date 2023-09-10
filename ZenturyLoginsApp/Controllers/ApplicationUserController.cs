using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ZenturyLoginsApp.BLL.Interfaces;
using ZenturyLoginsApp.Models.DTOs;

namespace ZenturyLoginsApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class ApplicationUserController : ControllerBase
    {
        private readonly ILogger<ApplicationUserController> _logger;
        private readonly IApplicationUserService _applicationUserService;

        public ApplicationUserController(ILogger<ApplicationUserController> logger, IApplicationUserService applicationUserService)
        {
            _logger = logger;
            _applicationUserService = applicationUserService;
        }

        [HttpGet("search")]
        public async Task<SearchResponse<UserDto>> SearchUsers([FromQuery] string? query = "", int page = 1, int pageSize = 10, string? sortColumn = "username", string? sortOrder = "asc")
        {
            try
            {
                var results = await _applicationUserService.SearchUsers(query, page, pageSize, sortColumn, sortOrder);
                return results;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return null;
            }
        }
    }
}
