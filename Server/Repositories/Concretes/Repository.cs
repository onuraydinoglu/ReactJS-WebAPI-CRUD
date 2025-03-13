using Microsoft.EntityFrameworkCore;
using Server.Entities;
using Server.Repositories.Abstracts;
using Server.Repositories.Context;

namespace Server.Repositories.Concretes
{
    public class Repository<T, TId> : IRepository<T, TId> where T : Entity<TId>
    {
        private readonly AppDbContext _context;
        private readonly DbSet<T> _dbSet;

        public Repository(AppDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            var products = await _dbSet.ToListAsync();
            return products;
        }

        public async Task<T> GetByIdAsync(TId id)
        {
            var product = await _dbSet.FindAsync(id);
            if (product is null)
            {
                throw new Exception($"Not found id: {id}");
            }
            return product;
        }

        public async Task AddAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
            await SaveAsync();
        }

        public async Task UpdateAsync(T entity)
        {
            if (entity.Id == null)
                throw new Exception("Entity ID cannot be null.");

            var updateEntity = await GetByIdAsync(entity.Id);
            _dbSet.Update(updateEntity);
            await SaveAsync();
        }

        public async Task DeleteAsync(TId id)
        {
            var deleteEntity = await GetByIdAsync(id);
            _dbSet.Remove(deleteEntity);
            await SaveAsync();
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}