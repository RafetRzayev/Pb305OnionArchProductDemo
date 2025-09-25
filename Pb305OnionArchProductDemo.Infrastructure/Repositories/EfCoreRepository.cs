using Microsoft.EntityFrameworkCore;
using Pb305OnionArchProductDemo.Domain.Entities;
using Pb305OnionArchProductDemo.Domain.Interfaces;
using Pb305OnionArchProductDemo.Infrastructure.DataContext;

namespace Pb305OnionArchProductDemo.Infrastructure.Repositories
{
    public class EfCoreRepository<T> : IRepository<T> where T : Entity
    {
        private readonly AppDbContext _dbContext;

        public EfCoreRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public virtual async Task<T> AddAsync(T entity)
        {
            var qualifiedDbSet = _dbContext.Set<T>();

            var entityEntry = await qualifiedDbSet.AddAsync(entity);

            await _dbContext.SaveChangesAsync();

            return entityEntry.Entity;
        }

        public virtual async  Task DeleteAsync(int id)
        {
            var entity = await _dbContext.Set<T>().FindAsync(id);

            if (entity == null)
            {
                throw new Exception($"Entity not found, with given id  : {id}");
            }

            _dbContext.Set<T>().Remove(entity);
        }

        public virtual async Task<IEnumerable<T>> GetAllAsync()
        {
            var entities = await  _dbContext.Set<T>().ToListAsync();

            return entities;
        }

        public virtual async Task<T?> GetByIdAsync(int id)
        {
            var entity =  await _dbContext.Set<T>().FindAsync(id);

            return entity;
        }

        public virtual async Task UpdateAsync(T entity)
        {
            var qualifiedDbSet = _dbContext.Set<T>();

            qualifiedDbSet.Update(entity);
            await _dbContext.SaveChangesAsync();
        }
    }
}
