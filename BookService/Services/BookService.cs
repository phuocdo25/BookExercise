using AutoMapper;
using BookDomain.Dtos;
using BookDomain.Models;

namespace BookDomain.Services;
public class BookService : IBookService
{
    private static readonly List<Book> _books = new List<Book>();
    private readonly IMapper _mapper;

    public BookService(IMapper mapper)
    {
        _mapper = mapper;

        if (!_books.Any())
        {
            _books.Add(new Book { Id = Guid.NewGuid(), Title = "Book1", Author = "Author1", PublishedYear = 2000 });
            _books.Add(new Book { Id = Guid.NewGuid(), Title = "Book2", Author = "Author2", PublishedYear = 2005 });
            _books.Add(new Book { Id = Guid.NewGuid(), Title = "Book3", Author = "Author3", PublishedYear = 2005 });
        }
    }

    public IEnumerable<BookDto> GetAll()
    {
        return _mapper.Map<IEnumerable<BookDto>>(_books);
    }

    public BookDto GetById(Guid id)
    {
        var book = _books.FirstOrDefault(x => x.Id == id);

        return _mapper.Map<BookDto>(book);
    }

    public BookDto Create(BookDto book)
    {
        var newBook = new Book()
        {
            Id = Guid.NewGuid(),
            Author = book.Author,
            PublishedYear = book.PublishedYear,
            Title = book.Title,
        };

        _books.Add(newBook);
        return _mapper.Map<BookDto>(newBook);
    }

    public BookDto Update(Guid id, BookDto book)
    {
        var existingBook = _books.FirstOrDefault(x => x.Id == id);

        if (existingBook == null)
        {
            throw new ArgumentNullException(nameof(existingBook));
        }

        existingBook.Author = book.Author;
        existingBook.PublishedYear = book.PublishedYear;
        existingBook.Title = book.Title;

        return _mapper.Map<BookDto>(existingBook);
    }

    public bool Delete(Guid id)
    {
        var existingBook = _books.FirstOrDefault(x => x.Id == id);

        if (existingBook == null)
        {
            throw new ArgumentNullException(nameof(existingBook));
        }

        return _books.Remove(existingBook);
    }
}
