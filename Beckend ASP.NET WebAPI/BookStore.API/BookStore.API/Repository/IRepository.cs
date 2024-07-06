using BookStore.API.Models;

namespace BookStore.API.Repository;

public interface IRepository<T> where T : BaseEntity
{
    Task<IEnumerable<T>> GetAllAsync();
    Task<T?> GetByIdAsync(int id);
    Task<bool> AddAsync(T entity);
    Task<bool> RemoveByIdAsync(int id);
}