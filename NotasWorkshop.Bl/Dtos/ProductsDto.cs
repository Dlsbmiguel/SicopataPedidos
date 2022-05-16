using SicopataPedidos.Core.Base.BaseEntityDto;
using SicopataPedidos.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SicopataPedidos.Bl.Dtos
{
    public class ProductsDto: BaseEntityDto
    {
        public string? ProductName { get; set; }
        public double ProductPrice { get; set; }
        public string? ProductDescription { get; set; }
        public int InStock { get; set; }
        public virtual ICollection<Categories>? Categories { get; set; }
        public virtual ICollection<ShoppingList>? ShoppingLists { get; set; }
    }
}
