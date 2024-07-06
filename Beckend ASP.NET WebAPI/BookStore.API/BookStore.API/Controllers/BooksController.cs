using BookStore.API.Infrastructure;
using BookStore.API.Models;
using BookStore.API.Models.ModelsDTO;
using BookStore.API.Repository;
using BookStore.API.Services;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BooksController : ControllerBase
{
    private readonly BookService _bookService;

    public BooksController(BookService bookService)
    {
        _bookService = bookService;
    }
    
    [HttpGet]
    public async Task<ActionResult<IEnumerable<BookDTO>>> GetAllBooksAsync()
    {
        return Ok(await _bookService.GetAllBooksAsync());
    }
    
    [HttpGet("{id}")]
    public async Task<ActionResult<BookDTO>> GetBookByIdAsync([FromRoute] int id)
    {
        var book = await _bookService.GetBookByIdAsync(id);
        return book == null ? NotFound() : Ok(book);
    }
    
    [HttpPost]
    [ServiceFilter(typeof(ValidationFilter))]
    public async Task<ActionResult<BookDTO>> CreateBookAsync(BookDTO bookDTO)
    {
        var book = await _bookService.CreateBookAsync(bookDTO);
        return Ok(book);
    }
    
    [HttpPut("{id}")]
    [ServiceFilter(typeof(ValidationFilter))]
    public async Task<ActionResult<BookDTO>> UpdateBookAsync([FromRoute] int id, BookDTO bookDTO)
    {
        var book = await _bookService.UpdateBookAsync(id, bookDTO);
        return Ok(book);
    }
    
    [HttpDelete("{id}")]
    public async Task<ActionResult<int>> RemoveBookAsync([FromRoute] int id)
    {
        return await _bookService.RemoveBookAsync(id) ? Ok(id) : NotFound(id);
    }
}