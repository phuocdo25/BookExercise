using BookDomain.Dtos;

namespace BookDomain.Services;
public interface IBookService
{
    IEnumerable<BookDto> GetAll();
    BookDto? GetById(Guid id);
    BookDto Create(BookDto book);
    BookDto Update(Guid id, BookDto book);
    bool Delete(Guid id);
}
