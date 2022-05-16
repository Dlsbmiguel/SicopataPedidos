using SicopataPedidos.Core.Base.BaseDto;
using SicopataPedidos.Core.Base.BaseEntityDto;
using SicopataPedidos.Model.Entities;
using System.Text.Json.Serialization;

namespace SicopataPedidos.Bl.Dtos
{
    public class UserDto: BaseEntityDto
    {
        public string? Name { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public int? Wallet { get; set; }
        public bool IsAdmin { get; set; }
        
        public virtual ICollection<Orders>? Orders { get; set; }
        
        public virtual ICollection<ShoppingList>? ShoppingLists { get; set; }
    }
}
