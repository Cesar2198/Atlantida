using API.Core.Application.Contracts;
using API.Core.Domain.Generic;
using API.Infraestructure.Persistence;
using Microsoft.EntityFrameworkCore.Storage;
using System.Collections;

namespace API.Infraestructure.Services
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly TarjetaCreditoDbContext context;
        private Hashtable _repositories;

        public UnitOfWork(TarjetaCreditoDbContext context)
        {
            this.context = context;
        }

        public void Dispose()
        {
            context.Dispose();
        }

        public async Task<int> SaveChangesAsync()
        {
            return await context.SaveChangesAsync();
        }

        public async Task<IDbContextTransaction> TransactionScopeAsync()
        {
            return await context.Database.BeginTransactionAsync();
        }

        public IRepository<TEntity> Repository<TEntity>() where TEntity : BaseDomain
        {
            if (_repositories == null)
                _repositories = new Hashtable();

            var type = typeof(TEntity).Name;

            if (!_repositories.ContainsKey(type))
            {
                var repositoryType = typeof(Repository<>);
                var repositoryInstance = Activator.CreateInstance(repositoryType.MakeGenericType(typeof(TEntity)), context);
                _repositories.Add(type, repositoryInstance);
            }

            return (IRepository<TEntity>)_repositories[type];
        }
    }
}
