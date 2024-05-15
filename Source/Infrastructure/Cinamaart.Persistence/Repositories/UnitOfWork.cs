using Cinamaart.Application.Interfaces.Repositories;
using Cinamaart.Domain.Common;
using Cinamaart.Domain.Common.Interfaces;
using Cinamaart.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinamaart.Persistence.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly MainDBContext _dbContext;
        private Hashtable _repositories;

        public UnitOfWork(MainDBContext dbContext)
        {
            _dbContext = dbContext;
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
                catch (Exception)
                {
                    //Log Exception Handling message                      
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
                catch (Exception)
                {
                    //Log Exception Handling message                      
                    returnValue = 0;
                    transAction.Rollback();
                }
            }
            return returnValue;
        }
        public IGenericRepository<T> Repository<T>() where T : class, IEntity
        {
            if (_repositories is null)
                _repositories = new Hashtable();

            var type = typeof(T).Name;

            if (!_repositories.ContainsKey(type))
            {
                var repositoryType = typeof(GenericRepository<>);

                var repositoryInstance = Activator.CreateInstance(repositoryType.MakeGenericType(typeof(T)), _dbContext);

                _repositories.Add(type, repositoryInstance);
            }

            return (IGenericRepository<T>)_repositories[type];
        }
        public void Dispose()
        {
            _dbContext.Dispose();
            GC.SuppressFinalize(this);
        }

    }
}
