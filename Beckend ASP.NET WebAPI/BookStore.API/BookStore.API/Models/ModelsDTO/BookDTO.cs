namespace BookStore.API.Models.ModelsDTO;

public class BookDTO
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public int Year { get; set; }
    public decimal Price { get; set; }
    public string Language { get; set; }
    public string Author { get; set; }
    public string Category { get; set; } = null!;
    public string ImageUrl { get; set; }
    public int PageCount { get; set; }
    public int AvailableCount { get; set; }
}