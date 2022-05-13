using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Infrastructure;
using SicopataPedidos.Core.Base.BaseEntity;

namespace SicopataPedidos.Model.Contexts.NotasWorkshop
{
    public interface ISicopataPedidosDbContext : IDisposable
    {
        DatabaseFacade Database { get; }
        DbSet<T> GetDbSet<T>() where T : class, IBaseEntity;
        int SaveChanges();
        ChangeTracker ChangeTracker();
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
        EntityEntry<T> Entry<T>(T entity) where T : class;
    }
}
