using Microsoft.EntityFrameworkCore;

namespace Demo.Repository.UnitOfWork
{
    internal interface IUnitOfwork :IDisposable
    {
        DbContext Context { get; }
        public Task SaveChangesAsync();
    }
}
