﻿using API.Core.Domain.Generic;
using Microsoft.EntityFrameworkCore.Storage;

namespace API.Core.Application.Contracts
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<TEntity> Repository<TEntity>() where TEntity : BaseDomain;
        Task<int> SaveChangesAsync();
        Task<IDbContextTransaction> TransactionScopeAsync();
    }
}
