using Server.Entities;
using Server.Repositories.Concretes;

namespace Server.Repositories.Abstracts
{
    public interface IRepository<T, TId> where T : Entity<TId>
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIdAsync(TId id);
        Task AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(TId id);
    }
}