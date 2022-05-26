using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SicopataPedidos.Api.Controllers;
using SicopataPedidos.Bl.Dtos;
using SicopataPedidos.Model.Entities;
using SicopataPedidos.Services.Services;
using System.Threading.Tasks;

namespace SicopataPedidos.API.Controllers
{
    [Authorize(Roles = "True")]
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : BaseController<User, UserDto>
    {
        private readonly IUserService _userService;
        private readonly IHttpContextAccessor _contextAccessor;
        public UserController(IUserService userService, IMapper mapper, IHttpContextAccessor contextAccessor) : base(userService, mapper)
        {
            _userService = userService;
            _contextAccessor = contextAccessor;
        }

        //public async Task<IActionResult> GetCurrentUser()
        //{
        //    var dto = await GetAndCreateCurrentUserIfNoExist();
        //    return Ok(dto);

        //}


        //private Task GetAndCreateCurrentUserIfNoExist()
        //{
        //    var currentAdUser = GetCurrentADUser();
        //    var userCreated = 
        //}

        [HttpPost, AllowAnonymous]
        public override Task<IActionResult> Post([FromBody] UserDto entityDto)
        {
            return base.Post(entityDto);
        }

        [HttpGet, Route("getLoggedInUser"), AllowAnonymous]
        public async Task <ActionResult<UserDto>> GetLoggedInUser()
        {

            return await _userService.GetLoggedInUser();

        }
    }
}
