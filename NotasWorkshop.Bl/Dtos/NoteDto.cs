using SicopataPedidos.Core.Base.BaseEntityDto;

namespace SicopataPedidos.Bl.Dtos
{
    public class NoteDto : BaseEntityDto
    {
        public string Title { get; set; }
        public string Content { get; set; }
    }
}
