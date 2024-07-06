using BookStore.API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookStore.API.Configurations;

public class BookConfiguration : IEntityTypeConfiguration<Book>
{
    public void Configure(EntityTypeBuilder<Book> builder)
    {
        builder.Property(b => b.Title)
            .IsRequired()
            .HasMaxLength(30);

        builder.Property(b => b.Description)
            .HasMaxLength(2000);

        builder.Property(b => b.Author)
            .IsRequired()
            .HasMaxLength(30);

        builder.Property(e => e.Year)
            .IsRequired();
        
        builder.Property(e => e.ImageUrl)
            .HasMaxLength(200);

        builder.Property(e => e.PageCount)
            .IsRequired();

        builder.Property(e => e.AvailableCount)
            .IsRequired();
    }
}