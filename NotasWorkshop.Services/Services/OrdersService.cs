using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using SicopataPedidos.Bl.Dtos;
using SicopataPedidos.Model.Contexts.NotasWorkshop;
using SicopataPedidos.Model.Entities;
using SicopataPedidos.Model.Repositories;
using SicopataPedidos.Model.UnitOfWorks;
using SicopataPedidos.Services.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace SicopataPedidos.Services.Services
{
    public interface IOrdersService : IEntityCRUDService<Orders, OrdersDto>
    {
        Task<OrdersDto?> MakeOrder();
        Task<bool> ValidateWallet(Orders request);

    }

    public class OrdersService : EntityCRUDService<Orders, OrdersDto>, IOrdersService
    {
        private readonly IShoppingListService _shoppingListService;
        private readonly IGetLoggedInUserService _LoggedInUserService;
        private readonly IRepository<Products> _productsRepository;
        private readonly IEmailService _emailService;
        public OrdersService(IMapper mapper, IUnitOfWork<ISicopataPedidosDbContext> uow, IShoppingListService shoppingListService, IGetLoggedInUserService LoggedInUserService,
             IRepository<Products> productsRepository, IEmailService emailService) : base(mapper, uow)
        {
            _shoppingListService = shoppingListService;
            _LoggedInUserService = LoggedInUserService;
            _productsRepository = productsRepository;
            _emailService = emailService;
            
        }
        public async Task<OrdersDto?> MakeOrder()
        {

            var shoppingList = await _shoppingListService.GetListForUser(_LoggedInUserService.UserId);
            if(shoppingList == null) return null;
            
            if (shoppingList.Count() < 1)
                throw new ApplicationException("Shopping List is empty.");

            var order = new Orders();

            order.UserId = _LoggedInUserService.UserId;

            if (await ValidateWallet(order) == false)
            {
                throw new ApplicationException($"Not enough funds to generate this order");
            }

            foreach (var item in shoppingList)
            {
                if (item.Products.InStock >= item.ProductQuatity)
                {
                    order.OrderTotal += item.Products.ProductPrice * item.ProductQuatity;
                    item.Products.InStock -= item.ProductQuatity;
                    _productsRepository.Update(item.Products);
                    await _uow.Commit();
                }
                else
                {
                    throw new ApplicationException($"{item.Products.ProductName} have not enought stock for your order.");
                }
            }

            order.CreatedDate = DateTime.Now;

            _repository.Add(order);
            await _uow.Commit();

            _emailService.Send(_LoggedInUserService.Email, "Order Confirmation Email",
                $"This email was generated as a confirmation for an Order. Order Id is: {order.Id} and your total {order.OrderTotal}. Thank you for shopping with us!");

            return _mapper.Map<OrdersDto>(order);
        }
        public async Task<bool> ValidateWallet(Orders request)
        {
            var user = await _uow.context.GetDbSet<User>().Where(x => x.Id == request.UserId).FirstOrDefaultAsync();
            if (user.Wallet < request.OrderTotal)
            {
                return false;
            }
            return true;
        }

    }
}
