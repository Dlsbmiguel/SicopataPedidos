using Microsoft.Extensions.DependencyInjection;
using SicopataPedidos.Model.Contexts.NotasWorkshop;
using SicopataPedidos.Model.UnitOfWorks;
using SicopataPedidos.Model.UnitOfWorks.SicopataPedidos;

namespace SicopataPedidos.Model.IoC
{
    public static class ModelRegistry
    {
        public static void AddModelRegistry(this IServiceCollection services)
        {
            services.AddTransient<ISicopataPedidosDbContext, SicopataPedidosDbContext>();
            services.AddScoped<IUnitOfWork<ISicopataPedidosDbContext>, SicopataPedidosUnitOfWork>();
        }
    }
}
