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
        public ShoppingListService(IMapper mapper, IUnitOfWork<ISicopataPedidosDbContext> uow) : base(mapper, uow)
        {
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
