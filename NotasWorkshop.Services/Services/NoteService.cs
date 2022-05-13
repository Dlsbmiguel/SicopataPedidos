using AutoMapper;
using SicopataPedidos.Bl.Dtos;
using SicopataPedidos.Model.Contexts.NotasWorkshop;
using SicopataPedidos.Model.Entities;
using SicopataPedidos.Model.UnitOfWorks;
using SicopataPedidos.Services.Generic;

namespace SicopataPedidos.Services.Services
{
    public interface INoteService : IEntityCRUDService<Note, NoteDto>
    {
        // Agregar mas metodo al servicio
    }

    public class NoteService : EntityCRUDService<Note, NoteDto>, INoteService
    {
        public NoteService(IMapper mapper, IUnitOfWork<ISicopataPedidosDbContext> uow) 
            : base(mapper, uow)
        {
        }
    }
}
