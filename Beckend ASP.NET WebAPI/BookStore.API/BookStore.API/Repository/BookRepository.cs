using BookStore.API.DataAccess;
using BookStore.API.Models;

namespace BookStore.API.Repository;

public class BookRepository : Repository<Book>, IBookRepository
{
    public BookRepository(BookDbContext context) : base(context)
    {
    }
    
    public async Task<bool> UpdateAsync(Book entity)
    {
        var entityToUpdate = await _dbSet.FindAsync(entity.Id);
        if (entityToUpdate == null)
            return false;

        entityToUpdate.Title = entity.Title;
        entityToUpdate.Description = entity.Description;
        entityToUpdate.Year = entity.Year;
        entityToUpdate.Price = entity.Price;
        entityToUpdate.Language = entity.Language;
        entityToUpdate.Author = entity.Author;
        entityToUpdate.Category = entity.Category;
        entityToUpdate.ImageUrl = entity.ImageUrl;
        entityToUpdate.PageCount = entity.PageCount;
        entityToUpdate.AvailableCount = entity.AvailableCount;

        await SaveChangesAsync();
        return true;
    }
}