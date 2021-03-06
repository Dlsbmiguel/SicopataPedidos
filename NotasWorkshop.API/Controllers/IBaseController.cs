using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace SicopataPedidos.Api.Controllers
{

    public interface IODataController
    {
        Type TypeDto { get; set; }
        IMapper _mapper { get; set; }
    }

    public interface IBaseController : IODataController
    {

        
        UnprocessableEntityObjectResult UnprocessableEntity(object error);
        string TypeName { get; set; }
    }
}
