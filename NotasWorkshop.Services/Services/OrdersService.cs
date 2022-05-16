using AutoMapper;
using Microsoft.AspNetCore.Http;
using SicopataPedidos.Bl.Dtos;
using SicopataPedidos.Model.Contexts.NotasWorkshop;
using SicopataPedidos.Model.Entities;
using SicopataPedidos.Model.UnitOfWorks;
using SicopataPedidos.Services.Generic;
using System.Security.Claims;

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
     
    }
}
