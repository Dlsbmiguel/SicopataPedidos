using SicopataPedidos.Core.Base.BaseEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SicopataPedidos.Model.Entities
{
    public class Products: BaseEntity
    {
        public Products()
        {
            Categories = new HashSet<Categories>();
            ShoppingLists = new HashSet<ShoppingList>();
        }
        public string? ProductName { get; set; }
        public double ProductPrice { get; set; }
        public string ProductDescription { get; set; }
        public int InStock { get; set; }
        [JsonIgnore]
        public virtual ICollection<Categories> Categories { get; set; }
        [JsonIgnore]
        public virtual ICollection<ShoppingList> ShoppingLists { get; set; }

    }
}
