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
    public class LoginsController : ControllerBase
    {
        private readonly ILogger<LoginsController> _logger;
        private readonly ILoginsService _loginsService;

        public LoginsController(ILogger<LoginsController> logger, ILoginsService loginsService)
        {
            _logger = logger;
            _loginsService = loginsService;
        }

        [HttpGet("search")]
        public async Task<SearchResponse<LoginDto>> SearchLogins([FromQuery] string? query = "", int page = 1, int pageSize = 10)
        {
            try
            {
                var results = await _loginsService.SearchLogins(query, page, pageSize);
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
