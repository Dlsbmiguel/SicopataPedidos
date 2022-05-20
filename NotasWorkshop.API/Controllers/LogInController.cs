using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SicopataPedidos.Bl.Dtos;
using SicopataPedidos.Services.Services;

namespace SicopataPedidos.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LogInController : ControllerBase
    {
        private readonly ILogInService _logInService;
        public LogInController(ILogInService logInService, IMapper mapper)
        {
            _logInService = logInService;
        }

        [HttpPost]
        public async Task<IActionResult> LogIn(LogInDto request)
        {
            var authenticateUser = await _logInService.AuthenticateUser(request);

            if (authenticateUser == null) return NotFound("User not found");

            return Ok(authenticateUser);
        }
    }
}
