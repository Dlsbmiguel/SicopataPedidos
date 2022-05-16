using AutoMapper;
using SicopataPedidos.Bl.Dtos;
using SicopataPedidos.Model.Contexts.NotasWorkshop;
using SicopataPedidos.Model.Entities;
using SicopataPedidos.Model.UnitOfWorks;
using SicopataPedidos.Services.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SicopataPedidos.Services.Services
{
    public interface ICategoriesService : IEntityCRUDService<Categories, CategoriesDto>
    {
        // Agregar mas metodo al servicio
    }

    public class CategoriesService : EntityCRUDService<Categories, CategoriesDto>, ICategoriesService
    {
        public CategoriesService(IMapper mapper, IUnitOfWork<ISicopataPedidosDbContext> uow)
            : base(mapper, uow)
        {
        }
    }
}
