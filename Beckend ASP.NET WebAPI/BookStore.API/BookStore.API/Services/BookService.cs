using AutoMapper;
using BookStore.API.Models;
using BookStore.API.Models.ModelsDTO;
using BookStore.API.Repository;

namespace BookStore.API.Services;

public class BookService
{
    private readonly IMapper _bookMapper;
    private readonly IBookRepository _bookRepository;
    
    public BookService(IMapper bookMapper, IBookRepository bookRepository)
    {
        _bookMapper = bookMapper;
        _bookRepository = bookRepository;
    }
    
    public async Task<IEnumerable<BookDTO>> GetAllBooksAsync()
    {
        var books = await _bookRepository.GetAllAsync();
        return _bookMapper.Map<IEnumerable<BookDTO>>(books);
    }
    
    public async Task<BookDTO> GetBookByIdAsync(int id)
    {
        var book = await _bookRepository.GetByIdAsync(id);
        return _bookMapper.Map<BookDTO>(book);
    }
    
    public async Task<Book> CreateBookAsync(BookDTO bookDTO)
    {
        var book = _bookMapper.Map<Book>(bookDTO);
        await _bookRepository.AddAsync(book);
        return book;
    }
    
    public async Task<BookDTO> UpdateBookAsync(int id, BookDTO bookDTO)
    {
        var book = _bookMapper.Map<Book>(bookDTO);
        book.Id = id;
        await _bookRepository.UpdateAsync(book);
        return _bookMapper.Map<BookDTO>(book);
    }
    
    public async Task<bool> RemoveBookAsync(int id)
    {
        return await _bookRepository.RemoveByIdAsync(id);
    }
}