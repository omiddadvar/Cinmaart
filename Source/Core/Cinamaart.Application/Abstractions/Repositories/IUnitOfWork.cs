namespace Cinamaart.Application.Interfaces.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        Task<int> SaveAsync(CancellationToken cancellationToken = default);
        int Save();

    }
}
