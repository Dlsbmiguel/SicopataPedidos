using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SicopataPedidos.Api.Controllers;
using SicopataPedidos.Bl.Dtos;
using SicopataPedidos.Model.Entities;
using SicopataPedidos.Services.Services;

namespace SicopataPedidos.API.Controllers
{
    [Authorize(Roles = "True")]
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : BaseController<User, UserDto>
    {
        public UserController(IUserService userService, IMapper mapper) : base(userService, mapper)
        {
        }

        [HttpPost, AllowAnonymous]
        public override Task<IActionResult> Post([FromBody] UserDto entityDto)
        {
            return base.Post(entityDto);
        }
    }
}
