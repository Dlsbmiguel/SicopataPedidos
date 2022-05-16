using SicopataPedidos.Core.Base.BaseEntityDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SicopataPedidos.Bl.Dtos
{
    public class LogInDto
    {
        public string? Email { get; set; }
        public string? Password { get; set; }
    }
}
