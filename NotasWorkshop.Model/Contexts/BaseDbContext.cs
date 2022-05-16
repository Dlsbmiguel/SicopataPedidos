using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.Extensions.Options;
using SicopataPedidos.Core.Settings;
using SicopataPedidos.Model.Entities;

namespace SicopataPedidos.Model.Contexts
{
    public abstract class BaseDbContext : DbContext
    {
        private readonly string? _userEmail;
        private readonly AppSettings? _appSettings;
        public BaseDbContext(DbContextOptions options, IOptions<AppSettings>? appSettings = null) : base(options)
        {
            _appSettings = appSettings?.Value;
        }

        /// <summary>
        /// Nos dice que sucede segun las acciones de SQL
        /// </summary>

        #region Definiendo los guardados dentro de la aplicacion

        public override int SaveChanges()
        {
            return base.SaveChanges();
        }
        public override int SaveChanges(bool acceptAllChangesOnSuccess)
        {
            return SaveChanges(acceptAllChangesOnSuccess);
        }
        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            return await base.SaveChangesAsync(cancellationToken);
        }
        #endregion

        public override ChangeTracker ChangeTracker => base.ChangeTracker;

        // Definiendo que pasa durante la creacion de un modelo
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ShoppingList>()
                .HasOne(u => u.User)
                .WithMany(sl => sl.ShoppingLists)
                .HasForeignKey(u => u.UserId);

            modelBuilder.Entity<ShoppingList>()
                .HasOne(u => u.Products)
                .WithMany(sl => sl.ShoppingLists)
                .HasForeignKey(u => u.ProductId);

            base.OnModelCreating(modelBuilder);
        }
    }
}
