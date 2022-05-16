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
    public class LogInProfile: Profile
    {
        public LogInProfile()
        {
            CreateMap<User, LogInDto>().ReverseMap();
        }
    }
}
