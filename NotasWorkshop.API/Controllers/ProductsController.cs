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
    public class ProductsController : BaseController<Products, ProductsDto>
    {
        private readonly ICategoriesProductsService _categoriesProductsService;
        public ProductsController(IProductsService productsService, IMapper mapper, ICategoriesProductsService categoriesProductsService) : base(productsService, mapper)
        {
            _categoriesProductsService = categoriesProductsService;
        }

        [HttpPost("AddCategoryToProduct")]
        public async Task<IActionResult> AddCategoryToProduct(CategoriesProductsDto request)
        {
            var product = await _categoriesProductsService.AddCategoryToProduct(request);

            if (product == null) return NotFound();

            return Ok(product);
        }
    }
}
