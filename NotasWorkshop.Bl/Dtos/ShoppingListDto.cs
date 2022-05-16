using SicopataPedidos.Core.Base.BaseEntityDto;
using SicopataPedidos.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SicopataPedidos.Bl.Dtos
{
    public class ShoppingListDto: BaseEntityDto
    {
        public int ProductId { get; set; }
        public int UserId { get; set; }
        public int ProductQuatity { get; set; }
        public int Price { get; set; }
    }
}
