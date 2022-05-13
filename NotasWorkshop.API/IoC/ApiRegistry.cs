using SicopataPedidos.Core.Settings;

namespace SicopataPedidos.API.IoC
{
    public static class ApiRegistry
    {
        public static void AddApiRegistry(this IServiceCollection services)
        {

        }

        public static void GetConfigurationSections(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<ConnectionStrings>(configuration.GetSection("ConnectionStrings"));
            services.Configure<AppSettings>(configuration.GetSection("AppSettings"));
        }
    }
}
