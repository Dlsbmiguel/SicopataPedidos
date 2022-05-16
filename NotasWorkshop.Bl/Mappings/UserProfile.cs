using AutoMapper;
using SicopataPedidos.Bl.Dtos;
using SicopataPedidos.Model.Entities;

namespace SicopataPedidos.Bl.Mappings
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User, UserDto>().ReverseMap();
        }
    }
}
