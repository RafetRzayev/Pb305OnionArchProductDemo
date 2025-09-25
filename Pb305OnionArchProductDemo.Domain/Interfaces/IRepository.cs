using Pb305OnionArchProductDemo.Domain.Entities;

namespace Pb305OnionArchProductDemo.Domain.Interfaces;

public interface IRepository<T> where T : Entity
{
    Task<IEnumerable<T>> GetAllAsync();
    Task<T?> GetByIdAsync(int id);
    Task<T> AddAsync(T entity);
    Task UpdateAsync(T entity);
    Task DeleteAsync(int id);
}