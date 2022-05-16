using SicopataPedidos.Core.Base.BaseEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SicopataPedidos.Model.Entities
{
    public class Categories: BaseEntity
    {
        public Categories()
        {
            Products = new HashSet<Products>();
        }
        public string? CategoryName { get; set; }
        [JsonIgnore]
        public ICollection<Products> Products { get; set; }
    }
}
