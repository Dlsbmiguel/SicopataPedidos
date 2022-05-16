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
    public class ProductsProfile: Profile
    {
        public ProductsProfile()
        {
            CreateMap<Products, ProductsDto>().ReverseMap();
        }
    }
}
