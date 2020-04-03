using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace Announcer.Contracts.v1
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<T> GetRepository<T>() where T : class, IEntity;

        int Save();

        Task<int> SaveAsync();
    }

    public interface IUnitOfWork<TContext> : IUnitOfWork where TContext : DbContext
    {
    }
}