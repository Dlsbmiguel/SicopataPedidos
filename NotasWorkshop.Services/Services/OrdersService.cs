using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using SicopataPedidos.Bl.Dtos;
using SicopataPedidos.Model.Contexts.NotasWorkshop;
using SicopataPedidos.Model.Entities;
using SicopataPedidos.Model.UnitOfWorks;
using SicopataPedidos.Services.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace SicopataPedidos.Services.Services
{
    public interface IOrdersService : IEntityCRUDService<Orders, OrdersDto>
    {
        
    }

    public class OrdersService : EntityCRUDService<Orders, OrdersDto>, IOrdersService
    {
        public OrdersService(IMapper mapper, IUnitOfWork<ISicopataPedidosDbContext> uow) : base(mapper, uow)
        {
        }

        public async Task<bool> ValidateWallet(UserDto request)
        {
            var user = await _uow.context.GetDbSet<User>().Where(x => x.Id == request.Id).FirstOrDefaultAsync();
            if (user.Wallet < request.Wallet)
            {
                return false;
            }
            return true;
        }

    }
}
