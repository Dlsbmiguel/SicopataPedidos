using SicopataPedidos.Core.Base.BaseEntity;

namespace SicopataPedidos.Model.Entities
{
    public class Note : BaseEntity
    {
        public string Title { get; set; }
        public string Content { get; set; }
    }
}
