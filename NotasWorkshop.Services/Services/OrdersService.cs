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
        public async Task<OrderResponseDto> MakeOrder()
        {
            var shoppingList = await _shoppingListRepository.GetListForUser(_loggedInUserService.UserId);
            var itemsToOrder = shoppingList.Where(item => item.OrderId == null).ToList();

            if (itemsToOrder.Count() < 1)
                throw new ApplicationException("Shopping List is empty.");

            var order = new Order();

            order.UserId = _loggedInUserService.UserId;

            foreach (var item in itemsToOrder)
            {
                if (item.Product.Stock >= item.Quantity)
                {
                    order.Total += item.Product.Price * item.Quantity;
                    item.Product.Stock -= item.Quantity;
                    await _productRepository.UpdateAsync(item.Product);
                }
                else
                {
                    throw new ApplicationException($"{item.Product.Name} have not enought stock for your order.");
                }
            }

            order.ShoppingList = itemsToOrder.ToList();

            order.Date = DateTimeOffset.Now;

            var result = await _orderRepository.AddAsync(order);

            foreach (var item in result.ShoppingList)
            {
                item.OrderId = result.Id;
                await _shoppingListRepository.UpdateAsync(item);
            }

            var response = _mapper.Map<OrderResponseDto>(result);
            response.UserName = _loggedInUserService.UserName;

            return response;
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
