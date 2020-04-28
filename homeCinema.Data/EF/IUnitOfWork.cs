using System;
using System.Threading.Tasks;

namespace homeCinema.Data.EF
{
    public interface IUnitOfWork : IDisposable
    {
        Task CommitAsync();
    }
}
