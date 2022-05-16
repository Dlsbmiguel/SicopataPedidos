using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SicopataPedidos.Bl.Dtos;
using SicopataPedidos.Model.Contexts.NotasWorkshop;
using SicopataPedidos.Model.Entities;
using SicopataPedidos.Model.UnitOfWorks;

namespace SicopataPedidos.Services.Services
{
    public interface ICategoriesProductsService
    {
        Task<ProductsDto> AddCategoryToProduct(CategoriesProductsDto request);
    }
    public class CategoriesProductsService : ICategoriesProductsService
    {
        private readonly IUnitOfWork<ISicopataPedidosDbContext> _uow;
        private readonly IMapper _mapper;
        public CategoriesProductsService(IUnitOfWork<ISicopataPedidosDbContext> uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }
        public async Task<ProductsDto> AddCategoryToProduct(CategoriesProductsDto request)
        {
            var product = await _uow.context.GetDbSet<Products>()
                .Where(c => c.Id == request.ProductsId)
                .Include(c => c.Categories)
                .FirstOrDefaultAsync();
            if (product == null) return null;

            var category = await _uow.context.GetDbSet<Categories>().FindAsync(request.CategoriesId);
            if (category == null) return null;

            product.Categories.Add(category);
            await _uow.context.SaveChangesAsync();

            return _mapper.Map<ProductsDto>(product);
        }
    }
}
