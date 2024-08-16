using BookApi.Controllers;
using BookDomain.Dtos;
using BookDomain.Services;
using Moq;

namespace TestBook.Controller;

[TestClass]
public class BookControllerTest
{
    private readonly BookController _bookController;
    private readonly Mock<IBookService> _mockBookService;

    public BookControllerTest()
    {
        _mockBookService = new Mock<IBookService>();
        _bookController = new BookController(_mockBookService.Object);
    }

    [TestMethod]
    public void GetAll_Successful()
    {
        //Arrange
        var bookDto = new BookDto()
        {
            Id = Guid.NewGuid(),
            Title = "test",
            Author = "1",
            PublishedYear = 1
        };

        var expected = new List<BookDto>() { bookDto };

        _mockBookService.Setup(x => x.GetAll()).Returns(expected);

        //Act
        var result = _bookController.GetAll();

        //Assert
        Assert.IsNotNull(result);
    }
}
