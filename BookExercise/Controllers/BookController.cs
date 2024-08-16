using BookDomain.Dtos;
using BookDomain.Services;
using Microsoft.AspNetCore.Mvc;

namespace BookApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BookController : ControllerBase
{
    private const string AuthHeader = "xAuth";
    private readonly IBookService _bookService;

    public BookController(IBookService bookService)
    {
        _bookService = bookService;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public IActionResult GetAll()
    {
        return Ok(_bookService.GetAll());
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult GetById(Guid id)
    {
        //if (!IsValidAuth()) return Unauthorized();
        var book = _bookService.GetById(id);
        if (book == null)
        {
            return NotFound();
        }

        return Ok(_bookService.GetById(id));
    }

    [HttpPost]
    public IActionResult Create([FromBody] BookDto book)
    {
        return Ok(_bookService.Create(book));
    }

    [HttpPut("{id}")]
    public IActionResult Update(Guid id, [FromBody] BookDto book)
    {
        return Ok(_bookService.Update(id, book));
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(Guid id)
    {
        return Ok(_bookService.Delete(id));
    }
}
