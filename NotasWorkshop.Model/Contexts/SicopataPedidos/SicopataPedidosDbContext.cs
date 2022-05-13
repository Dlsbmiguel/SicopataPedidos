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

        public DbSet<Note> Notes { get; set; }

        public DbSet<T> GetDbSet<T>() where T : class, IBaseEntity => Set<T>();

        ChangeTracker ISicopataPedidosDbContext.ChangeTracker()
        {
            return base.ChangeTracker;
        }
    }
}
