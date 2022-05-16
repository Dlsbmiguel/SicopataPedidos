using SicopataPedidos.Core.Base.BaseEntity;
using System.Text.Json.Serialization;

namespace SicopataPedidos.Model.Entities
{
    public class ShoppingList : BaseEntity
    {
        public int ProductId { get; set; }
        public int UserId { get; set; }
        public int ProductQuatity { get; set; }
        public double Price { get; set; }
        [JsonIgnore]
        public virtual Products? Products { get; set; }
        [JsonIgnore]
        public virtual User? User { get; set; }
    }
}
