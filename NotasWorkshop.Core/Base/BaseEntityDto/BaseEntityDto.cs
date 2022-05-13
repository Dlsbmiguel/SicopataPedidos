namespace SicopataPedidos.Core.Base.BaseEntityDto
{
    public class BaseEntityDto : BaseDto.BaseDto, IBaseEntityDto
    {
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public DateTimeOffset? CreatedDate { get; set; }
    }
}
