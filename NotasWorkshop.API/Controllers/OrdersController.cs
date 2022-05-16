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
    [Authorize(Roles = "True")]
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : BaseController<Orders, OrdersDto>
    {
        private readonly IEmailService _emailService;
        public OrdersController(IOrdersService ordersService, IMapper mapper, IEmailService emailService) : base(ordersService, mapper)
        {
            _emailService = emailService;
        }

        [HttpPost, Authorize(Roles = "False")]
        public async override Task<IActionResult> Post([FromBody] OrdersDto entityDto)
        {
            entityDto = await _entityCRUDService.Save(entityDto);
            
            var userEmail = User.FindFirstValue(ClaimTypes.Email);

            _emailService.Send(userEmail, "Order Confirmation Email",
                $"This email was generated as a confirmation for an Order. Order Id is: {entityDto.Id} and your total {entityDto.OrderTotal}. Thank you for shopping with us!");

            return Ok("Your order was created, a confirmation email has been sent to your email address!");
        }
    }
}
