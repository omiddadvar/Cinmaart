using Cinamaart.Domain.Common;
using Cinamaart.Domain.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinamaart.Application.Interfaces.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        IGenericRepository<T> Repository<T>() where T : class, IEntity;
        Task<int> SaveAsync(CancellationToken cancellationToken);
        int Save();

    }
}
