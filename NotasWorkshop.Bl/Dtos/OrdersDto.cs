using SicopataPedidos.Core.Base.BaseEntityDto;

namespace SicopataPedidos.Bl.Dtos
{
    public class OrdersDto : BaseEntityDto
    {
        public double OrderTotal { get; set; }
        public DateTime CreatedDate { get; set; }
        public int? UserId { get; set; }
    }
}
