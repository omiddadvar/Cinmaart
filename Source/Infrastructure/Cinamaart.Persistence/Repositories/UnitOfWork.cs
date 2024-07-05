using Cinamaart.Application.Interfaces.Repositories;
using Cinamaart.Persistence.Contexts;
using Microsoft.Extensions.Logging;

namespace Cinamaart.Persistence.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly MainDBContext _dbContext;
        private readonly ILogger<UnitOfWork> _logger;

        public UnitOfWork(MainDBContext dbContext, ILogger<UnitOfWork> logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }

        public async Task<int> SaveAsync(CancellationToken cancellationToken)
        {
            int returnValue = 0;
            using (var transAction = _dbContext.Database.BeginTransaction())
            {
                try
                {
                    returnValue = await _dbContext.SaveChangesAsync(cancellationToken);
                    transAction.Commit();
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Exception occured : {Message}", ex.Message);
                    returnValue = 0;
                    transAction.Rollback();
                }
            }
            return returnValue;
        }
        public int Save()
        {
            int returnValue = 0;
            using (var transAction = _dbContext.Database.BeginTransaction())
            {
                try
                {
                    returnValue = _dbContext.SaveChanges();
                    transAction.Commit();
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Exception occured : {Message}", ex.Message);
                    returnValue = 0;
                    transAction.Rollback();
                }
            }
            return returnValue;
        }
        public void Dispose()
        {
            _dbContext.Dispose();
            GC.SuppressFinalize(this);
        }

    }
}
