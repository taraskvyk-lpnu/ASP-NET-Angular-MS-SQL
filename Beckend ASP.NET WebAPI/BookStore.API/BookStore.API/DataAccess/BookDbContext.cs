using BookStore.API.Configurations;
using BookStore.API.Models;
using Microsoft.EntityFrameworkCore;

namespace BookStore.API.DataAccess;

public class BookDbContext : DbContext
{
    public BookDbContext(DbContextOptions<BookDbContext> options) : base(options)
    {
        
    }
    
    public DbSet<Book> Books { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfiguration(new BookConfiguration());
    }
}