using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SicopataPedidos.Bl.Dtos;
using SicopataPedidos.Model.Contexts.NotasWorkshop;
using SicopataPedidos.Model.Entities;
using SicopataPedidos.Model.UnitOfWorks;
using SicopataPedidos.Services.Generic;

namespace SicopataPedidos.Services.Services
{
    public interface IUserService : IEntityCRUDService<User, UserDto>
    {
        Task<UserDto?> GetLoggedInUser();
    }

    public class UserService : EntityCRUDService<User, UserDto>, IUserService
    {
        private readonly IGetLoggedInUserService _LoggedInUserService;
        public UserService(IMapper mapper, IUnitOfWork<ISicopataPedidosDbContext> uow, IGetLoggedInUserService loggedInUserService)
            : base(mapper, uow)
        {
            _LoggedInUserService = loggedInUserService;
        }

        public override async Task<UserDto> GetById(int id)
        {
            if (_repository is null) return new UserDto();
            var user = await _repository.GetAll().Include(x => x.ShoppingLists).Include(x => x.Orders).Where(x => x.Id == id).FirstOrDefaultAsync();
            return _mapper.Map<UserDto>(user);
        }

        public  async Task<UserDto?> GetLoggedInUser()
        {
            var id = _LoggedInUserService.UserId;
            if (id == 0) return null;

            if (_repository is null) return new UserDto();
            var user = await _repository.GetAll().Where(x => x.Id == id).FirstOrDefaultAsync();
            return _mapper.Map<UserDto>(user);
        }
    }
}
