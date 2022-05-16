using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SicopataPedidos.Bl.Dtos;
using SicopataPedidos.Model.Contexts.NotasWorkshop;
using SicopataPedidos.Model.Entities;
using SicopataPedidos.Model.UnitOfWorks;
using SicopataPedidos.Services.Generic;

namespace SicopataPedidos.Services.Services
{
    public interface IProductsService : IEntityCRUDService<Products, ProductsDto>
    {
        // Agregar mas metodo al servicio
    }

    public class ProductsService : EntityCRUDService<Products, ProductsDto>, IProductsService
    {
        public ProductsService(IMapper mapper, IUnitOfWork<ISicopataPedidosDbContext> uow) : base(mapper, uow)
        {
        }

        public override async Task<ProductsDto> GetById(int id)
        {
            if (_repository is null) return new ProductsDto();
            var products = await _repository.GetAll().Include(x => x.ShoppingLists).Include(x => x.Categories).Where(x => x.Id == id).FirstOrDefaultAsync();
            return _mapper.Map<ProductsDto>(products);
        }
    }
}
