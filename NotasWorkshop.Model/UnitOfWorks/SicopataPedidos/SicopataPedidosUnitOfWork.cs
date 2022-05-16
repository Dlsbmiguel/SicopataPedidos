using SicopataPedidos.Model.Contexts.NotasWorkshop;
using SicopataPedidos.Model.Repositories;
using SicopataPedidos.Core.Base.BaseEntity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SicopataPedidos.Model.UnitOfWorks.SicopataPedidos
{
    public class SicopataPedidosUnitOfWork : IUnitOfWork<ISicopataPedidosDbContext>
    {
        public ISicopataPedidosDbContext context { get; set; }
        public readonly IServiceProvider _serviceProvider;

        public SicopataPedidosUnitOfWork(IServiceProvider serviceProvider, ISicopataPedidosDbContext context)
        {
            _serviceProvider = serviceProvider;
            this.context = context;
        }

        public async Task<int> Commit()
        {
            var result = await context.SaveChangesAsync();
            return result;
        }

        public void Dispose()
        {
            context.Dispose();
        }

        public IRepository<TEntity> GetRepository<TEntity>() where TEntity : class, IBaseEntity
        {
            return (_serviceProvider.GetService(typeof(TEntity)) ?? new BaseRepository<TEntity>(this)) as IRepository<TEntity>;
        }
    }
}
