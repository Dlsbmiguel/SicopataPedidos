using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.Extensions.Options;
using SicopataPedidos.Core.Base.BaseEntity;
using SicopataPedidos.Core.Settings;
using SicopataPedidos.Model.Entities;

namespace SicopataPedidos.Model.Contexts.NotasWorkshop
{
    public class SicopataPedidosDbContext : BaseDbContext, ISicopataPedidosDbContext
    {
        public SicopataPedidosDbContext(DbContextOptions<SicopataPedidosDbContext> options,
            IOptions<AppSettings> appSettings)
            : base(options, appSettings)
        {
        }

        public DbSet<Categories> Categories { get; set; }
        public DbSet<Orders> Orders { get; set; }
        public DbSet<Products> Products { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<ShoppingList> ShoppingLists { get; set; }


        public DbSet<T> GetDbSet<T>() where T : class, IBaseEntity => Set<T>();

        ChangeTracker ISicopataPedidosDbContext.ChangeTracker()
        {
            return base.ChangeTracker;
        }
    }
}
