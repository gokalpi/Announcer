using Announcer.Contracts.v1;
using Announcer.Data.Contexts.v1;
using Announcer.Data.Repositories.v1;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Announcer.Data.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AnnouncerDbContext _context;
        private Dictionary<Type, object> _repositories;

        public UnitOfWork(AnnouncerDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public int Save()
        {
            return _context.SaveChanges();
        }

        public async Task<int> SaveAsync()
        {
            return await _context.SaveChangesAsync();
        }

        IRepository<T> IUnitOfWork.GetRepository<T>()
        {
            if (_repositories == null) _repositories = new Dictionary<Type, object>();

            var type = typeof(T);
            if (!_repositories.ContainsKey(type)) _repositories[type] = new Repository<T>(_context);

            return (IRepository<T>)_repositories[type];
        }

        #region IDisposable Support

        private bool _disposed = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }

                _disposed = true;
            }
        }

        ~UnitOfWork()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(false);
        }

        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        #endregion IDisposable Support
    }
}