
using AutoMapper;
using BookDomain.Dtos;
using BookDomain.Models;

namespace BookDomain;
public class BookAutoMapper : Profile
{
    public BookAutoMapper()
    {
        CreateMap<Book, BookDto>();
    }
}
