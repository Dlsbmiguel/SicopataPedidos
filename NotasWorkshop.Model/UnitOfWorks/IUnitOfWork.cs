using SicopataPedidos.Model.Repositories;
using SicopataPedidos.Core.Base.BaseEntity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SicopataPedidos.Model.UnitOfWorks
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<TEntity> GetRepository<TEntity>() where TEntity : class, IBaseEntity;
        Task<int> Commit();
    }

    public interface IUnitOfWork<TContext> : IUnitOfWork
    {
        TContext context { get; }
    }
}
