using AutoMapper;
using SicopataPedidos.Bl.Dtos;
using SicopataPedidos.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SicopataPedidos.Bl.Mappings
{
    public class ShoppingListProfile: Profile
    {
        public ShoppingListProfile()
        {
            CreateMap<ShoppingList, ShoppingListDto>().ReverseMap();
            //CreateMap<ShoppingList, ShoppingListDto>().ForMember(dest => dest.Products, opt => opt.MapFrom(src => src.Products));
        }
    }
}
