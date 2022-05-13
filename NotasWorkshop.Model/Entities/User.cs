using SicopataPedidos.Core.Base.BaseEntity;

namespace SicopataPedidos.Model.Entities
{
    public class User : BaseEntity
    {
        public string? Name { get; set; }
        public string? LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int? Wallet { get; set; }
        public bool IsAdmin { get; set; }
    }
}
