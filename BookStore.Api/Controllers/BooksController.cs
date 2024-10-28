using BookStore.Datas.Services;
using BookStore.Datas.UnitOfWork;
using BookStore.Models.Models;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly BookService _bookService;
        private readonly IUnitOfWork _unitOfWork;

        public BooksController(BookService bookService, IUnitOfWork unitOfWork)
        {
            _bookService = bookService;
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<IActionResult> GetBooks(int? authorId, DateTime? publishYear, int page = 1, int pageSize = 10)
        {
            var books = await _bookService.GetBooks(authorId, publishYear, page, pageSize);
            return Ok(books);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBookById(int id)
        {
            var book = await _bookService.GetByIdAsync(id);
            if (book == null) return NotFound();
            return Ok(book);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllBooks()
        {
            var books = await _bookService.GetAllAsync();
            return Ok(books);
        }

        [HttpPost]
        public async Task<IActionResult> CreateBook([FromBody] Book book)
        {
            await _bookService.AddAsync(book);
            await _unitOfWork.CompleteAsync();
            return CreatedAtAction(nameof(GetBookById), new { id = book.BookId }, book);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBook(int id, [FromBody] Book updatedBook)
        {
            var book = await _bookService.GetByIdAsync(id);
            if (book == null) return NotFound();

            // Update book properties
            book.Title = updatedBook.Title;
            book.Price = updatedBook.Price;
            book.PublishDate = updatedBook.PublishDate;
            book.AuthorId = updatedBook.AuthorId;

            _bookService.Update(book);
            await _unitOfWork.CompleteAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBook(int id)
        {
            var book = await _bookService.GetByIdAsync(id);
            if (book == null) return NotFound();

            _bookService.Delete(book);
            await _unitOfWork.CompleteAsync();

            return NoContent();
        }
    }
}
