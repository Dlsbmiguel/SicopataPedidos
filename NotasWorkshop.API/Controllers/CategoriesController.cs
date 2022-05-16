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
    public class CategoriesController : BaseController<Categories, CategoriesDto>
    {
        public CategoriesController(ICategoriesService categoriesService, IMapper mapper) : base(categoriesService, mapper)
        {
        }
    }
}
