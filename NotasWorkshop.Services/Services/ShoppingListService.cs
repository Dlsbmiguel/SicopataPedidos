using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SicopataPedidos.Bl.Dtos;
using SicopataPedidos.Model.Contexts.NotasWorkshop;
using SicopataPedidos.Model.Entities;
using SicopataPedidos.Model.UnitOfWorks;
using SicopataPedidos.Services.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SicopataPedidos.Services.Services
{
    public interface IShoppingListService : IEntityCRUDService<ShoppingList, ShoppingListDto>
    {
        // Agregar mas metodo al servicio
        
        Task<IReadOnlyCollection<ShoppingList>> GetListForUser(int userId);
    }

    public class ShoppingListService : EntityCRUDService<ShoppingList, ShoppingListDto>, IShoppingListService
    {
        private readonly IGetLoggedInUserService _isLoggedInUserService;
        public ShoppingListService(IMapper mapper, IUnitOfWork<ISicopataPedidosDbContext> uow, IGetLoggedInUserService isLoggedInService) : base(mapper, uow)
        {
            _isLoggedInUserService = isLoggedInService;
        }

        public override async Task<ShoppingListDto> Save(ShoppingListDto entityDto)
        {
            var id = _isLoggedInUserService.UserId;
            entityDto.UserId = id;

            var product = _uow.GetRepository<Products>().Where(x => x.Id == entityDto.ProductId).FirstOrDefault();

            entityDto.Price = product.ProductPrice * entityDto.ProductQuatity;
            
            ShoppingList entity = _mapper.Map<ShoppingList>(entityDto);
            _repository.Add(entity);
            await _uow.Commit();
            
            entityDto = _mapper.Map<ShoppingListDto>(entity);

            return entityDto;
        }

        public async Task<IReadOnlyCollection<ShoppingList>> GetListForUser(int userId)
        {
            var list = await _uow.GetRepository<ShoppingList>().Where(i => i.UserId == userId)
                    .Include(i => i.Products)
                    .ToListAsync();

            return list;
        }
    }
}
