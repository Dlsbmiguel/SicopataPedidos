using AutoMapper;
using SicopataPedidos.Bl.Dtos;
using SicopataPedidos.Bl.Extensions;
using SicopataPedidos.Model.Entities;

namespace SicopataPedidos.Bl.Mappings
{
    public class NoteProfile : Profile
    {
        public NoteProfile()
        {
            this._CreateMap_WithConventions_FromAssemblies<Note, NoteDto>();

            /// CreateMap<Note, NoteDto>().ReverseMap();
            /// CreateMap<User, UserDto>().ReverseMap();
        }
    }
}
