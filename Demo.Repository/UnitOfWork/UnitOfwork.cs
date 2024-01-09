using Demo.EntityFramework.Models;
using Microsoft.EntityFrameworkCore;

namespace Demo.Repository.UnitOfWork
{
    internal class UnitOfwork : IUnitOfwork
    {
        private readonly Project5Context _context;
        private bool _disposed = false;

        public UnitOfwork(Project5Context context)
        {
            _context = context;
        }
        public DbContext Context => _context;

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

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
    }
}
