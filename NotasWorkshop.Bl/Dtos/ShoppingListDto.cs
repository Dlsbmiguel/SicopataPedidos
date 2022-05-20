using SicopataPedidos.Core.Base.BaseEntityDto;
using SicopataPedidos.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SicopataPedidos.Bl.Dtos
{
    public class ShoppingListDto: BaseEntityDto
    {
       
        public int ProductId { get; set; }
        public int UserId { get; set; }
        public int ProductQuatity { get; set; }
        public double Price { get; set; }
        public virtual Products? Products { get; set; }
        public virtual User? User { get; set; }
    }
}
