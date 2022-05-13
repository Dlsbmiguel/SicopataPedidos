using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SicopataPedidos.Services.Services;

namespace SicopataPedidos.Services.IoC
{
    public static class ServiceRegistry
    {
        public static void AddServicesRegistry(this IServiceCollection services)
        {
            services.AddScoped<INoteService, NoteService>();
        }
    }
}
