using LibraryManagement.BlazorServer.Models;
using LibraryManagement.BlazorServer.Services;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagement.BlazorServer.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BooksController : ControllerBase
    {

        private readonly IBookService _bookService;

        /// <summary>
        /// Point 4 Write a small example of how you would use Dependency Injection to inject the IBookService into a hypothetical BooksController. 
        /// </summary>
        /// <param name="bookService"></param>
        public BooksController(IBookService bookService)
        {
            _bookService = bookService;
        }

        // GET: api/books
        [HttpGet]
        public ActionResult<IEnumerable<Book>> GetBooks()
        {
            var books = _bookService.GetBooksAsync();
            return Ok(books);
        }

        // GET: api/books/{id}
        [HttpGet("{id}")]
        public ActionResult<Book> GetBook(int id)
        {
            var book = _bookService.GetBookByIdAsync(id);
            if (book == null)
                return NotFound();
            return Ok(book);
        }


        // POST: api/books
        [HttpPost]
        public ActionResult<Book> AddBook([FromBody] Book book)
        {
            _bookService.AddBookAsync(book);
            // Assumes service sets book.BookId
            return CreatedAtAction(nameof(GetBook), new { id = book.BookId }, book);
        }


        // PUT: api/books/{id}
        [HttpPut("{id}")]
        public IActionResult UpdateBook(int id, [FromBody] Book book)
        {
            if (id != book.BookId)
                return BadRequest("ID in URL must match BookId in payload.");

            var existing = _bookService.GetBookByIdAsync(id);
            if (existing == null)
                return NotFound();

            _bookService.UpdateBookAsync(book);
            return NoContent();
        }

        // DELETE: api/books/{id}
        [HttpDelete("{id}")]
        public IActionResult DeleteBook(int id)
        {
            var existing = _bookService.GetBookByIdAsync(id);
            if (existing == null)
                return NotFound();

            _bookService.DeleteBookAsync(id);
            return NoContent();
        }

    }
}
