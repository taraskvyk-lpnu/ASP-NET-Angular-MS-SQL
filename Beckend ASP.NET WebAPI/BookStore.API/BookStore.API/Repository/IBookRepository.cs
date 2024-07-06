using BookStore.API.DataAccess;
using BookStore.API.Models;

namespace BookStore.API.Repository;

public interface IBookRepository : IRepository<Book>
{
    public Task<bool> UpdateAsync(Book entity);
}