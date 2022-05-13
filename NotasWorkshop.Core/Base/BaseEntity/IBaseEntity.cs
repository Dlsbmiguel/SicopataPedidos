using SicopataPedidos.Core.Base.Base;

namespace SicopataPedidos.Core.Base.BaseEntity
{
    public interface IBaseEntity : IBase
    {
        DateTimeOffset? CreatedDate { get; set; }
        DateTimeOffset? UpdatedDate { get; set; }
        string CreatedBy { get; set; }
        string UpdatedBy { get; set; }
    }
}
