using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using SicopataPedidos.Api.Controllers;
using SicopataPedidos.Bl.Dtos;
using SicopataPedidos.Model.Entities;
using SicopataPedidos.Services.Services;

namespace SicopataPedidos.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class NotesController : BaseController<Note, NoteDto>
    {
        public NotesController(INoteService noteService,
            IValidatorFactory validationFactory,
            IMapper mapper)
            : base(noteService, validationFactory, mapper)
        {
        }
    }
}
