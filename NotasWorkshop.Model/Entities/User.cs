using SicopataPedidos.Core.Base.BaseEntity;
using System.Text.Json.Serialization;

namespace SicopataPedidos.Model.Entities
{
    public class User : BaseEntity
    {
        public User()
        {
            Orders = new HashSet<Orders>();
            ShoppingLists = new HashSet<ShoppingList>();
        }
        public string? Name { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public int? Wallet { get; set; }
        public bool IsAdmin { get; set; }
        [JsonIgnore]
        public virtual ICollection<Orders> Orders { get; set; }
        [JsonIgnore]
        public virtual ICollection<ShoppingList> ShoppingLists { get; set; }
    }
}
