using API.Core.Domain.Generic;

namespace API.Core.Application.Contracts
{
    public interface IRepository<T> where T : BaseDomain
    {
        Task<IReadOnlyList<T>> GetAllAsync();
        Task<T> GetByIdAsync(long id);
        Task InsertAsync(T entity);
        void Update(T entity);
        Task DeleteAsync(long id);
        IQueryable<T> GetQuery();
    }
}
