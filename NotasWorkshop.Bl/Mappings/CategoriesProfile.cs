using AutoMapper;
using SicopataPedidos.Bl.Dtos;
using SicopataPedidos.Model.Entities;

namespace SicopataPedidos.Bl.Mappings
{
    public class CategoriesProfile : Profile
    {
        public CategoriesProfile()
        {
            CreateMap<Categories, CategoriesDto>().ReverseMap();
        }
    }
}
