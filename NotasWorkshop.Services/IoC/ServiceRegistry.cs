using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SicopataPedidos.Services.Services;

namespace SicopataPedidos.Services.IoC
{
    public static class ServiceRegistry
    {
        public static void AddServicesRegistry(this IServiceCollection services)
        {
            services.AddScoped<ITokenCreationService, TokenCreationService>();
            services.AddTransient<ILogInService, LogInService>();
            services.AddScoped<ICategoriesService, CategoriesService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IProductsService, ProductsService>();
            services.AddScoped<IShoppingListService, ShoppingListService>();
            services.AddScoped<IOrdersService, OrdersService>();
            services.AddScoped<ICategoriesProductsService, CategoriesProductsService>();
            services.AddScoped<IEmailService, EmailService>();
        }
    }
}
