using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SicopataPedidos.Api.Controllers;
using SicopataPedidos.Bl.Dtos;
using SicopataPedidos.Model.Entities;
using SicopataPedidos.Services.Services;

namespace SicopataPedidos.API.Controllers
{
    [Authorize(Roles = "False")]
    [Route("api/[controller]")]
    [ApiController]
    public class ShoppingListController : BaseController<ShoppingList, ShoppingListDto>
    {
        public ShoppingListController(IShoppingListService shoppingListService, IMapper mapper) : base(shoppingListService, mapper)
        {
        }
    }
}
