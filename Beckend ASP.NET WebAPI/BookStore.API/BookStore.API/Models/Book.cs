using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices.JavaScript;

namespace BookStore.API.Models;

public class Book : BaseEntity
{
    public string Title { get; set; }
    public string Description { get; set; }
    [Range(0, 2024, ErrorMessage = "Year must be between 0 and current year")]
    public int Year { get; set; }
    
    [Range(0, 10000, ErrorMessage = "Year must be between 0 and current year")]
    public decimal Price { get; set; }
    public string Language { get; set; }
    public string Author { get; set; }
    public string Category { get; set; } = null!;
    public string ImageUrl { get; set; }
    
    [Range(10, 5000)]
    public int PageCount { get; set; }
    [Range(0, 500)]
    public int AvailableCount { get; set; }
}