using SicopataPedidos.Core.Base.BaseEntity;
using System.Text.Json.Serialization;

namespace SicopataPedidos.Model.Entities
{
    public class Orders : BaseEntity
    {
        public double OrderTotal { get; set; }
        public DateTime CreatedDate { get; set; }
        public int? UserId { get; set; }
        [JsonIgnore]
        public virtual User? User { get; set; }
    }
}
