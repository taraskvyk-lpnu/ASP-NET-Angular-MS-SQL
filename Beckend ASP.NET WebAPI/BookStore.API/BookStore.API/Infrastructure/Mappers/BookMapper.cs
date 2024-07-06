using AutoMapper;
using BookStore.API.Models;
using BookStore.API.Models.ModelsDTO;

namespace BookStore.API.Infrastructure.Mappers;

public class BookProfile : Profile
{
    public BookProfile()
    {
        CreateMap<Book, BookDTO>().ReverseMap();
    }
}