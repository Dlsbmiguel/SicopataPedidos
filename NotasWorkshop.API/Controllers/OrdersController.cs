using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SicopataPedidos.Api.Controllers;
using SicopataPedidos.Bl.Dtos;
using SicopataPedidos.Model.Entities;
using SicopataPedidos.Services.Services;
using System.Security.Claims;

namespace SicopataPedidos.API.Controllers
{
    [Authorize(Roles = "False")]
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : BaseController<Orders, OrdersDto>
    {
        private readonly IOrdersService _ordersService;
        public OrdersController(IOrdersService ordersService, IMapper mapper) : base(ordersService, mapper)
        {
            _ordersService = ordersService;
        }

        [HttpGet, Route("make")]
        public async Task<ActionResult<OrdersDto>> MakeOrder()
        {
            var result = await _ordersService.MakeOrder();
            return Ok(result); 
        }
    }
}
