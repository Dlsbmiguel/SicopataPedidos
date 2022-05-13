using SicopataPedidos.Core.Base.BaseDto;

namespace SicopataPedidos.Core.Base.BaseEntityDto
{
    public interface IBaseEntityDto : IBaseDto
    {
        string CreatedBy { get; set; }
        string UpdatedBy { get; set; }
    }
}
