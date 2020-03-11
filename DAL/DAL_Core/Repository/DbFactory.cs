using DAL.DAL_Core.Interfaces;
using DAL.EF;
using Microsoft.EntityFrameworkCore;
using System;

namespace DAL.DAL_Core.Repository
{
    public class DbFactory : Disposable, IDbFactory
    {
        DetailContext _dbContext;
        public DetailContext Init()
        {
            return _dbContext ??= new DetailContext(new DbContextOptions<DetailContext>());
        }

        protected override void DisposeCore()
        {
            _dbContext?.Dispose();
        }
    }

    public class Disposable : IDisposable
    {
        private bool _isDisposed;

        ~Disposable()
        {
            Dispose(false);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        private void Dispose(bool disposing)
        {
            if (!_isDisposed && disposing)
            {
                DisposeCore();
            }

            _isDisposed = true;
        }

        // Ovveride this to dispose custom objects
        protected virtual void DisposeCore()
        {
        }
    }
}