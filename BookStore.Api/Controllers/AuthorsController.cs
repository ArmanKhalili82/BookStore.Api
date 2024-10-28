using BookStore.Datas.Services;
using BookStore.Datas.UnitOfWork;
using BookStore.Models.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        private readonly AuthorService _authorService;
        private readonly IUnitOfWork _unitOfWork;

        public AuthorsController(AuthorService authorService, IUnitOfWork unitOfWork)
        {
            _authorService = authorService;
            _unitOfWork = unitOfWork;
        }

        [HttpGet("GetAllAuthors")]
        public async Task<IActionResult> GetAuthors()
        {
            var authors = await _authorService.GetAllAuthors();
            return Ok(authors);
        }
        
        // GET: api/authors/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAuthorById(int id)
        {
            var author = await _authorService.GetByIdAsync(id);
            if (author == null)
            {
                return NotFound();
            }
            return Ok(author);
        }

        // POST: api/authors
        [HttpPost]
        public async Task<IActionResult> CreateAuthor([FromBody] Author author)
        {
            if (author == null)
            {
                return BadRequest("Author object is null.");
            }

            await _authorService.AddAsync(author);
            await _unitOfWork.CompleteAsync();

            return CreatedAtAction(nameof(GetAuthorById), new { id = author.AuthorId }, author);
        }

        // PUT: api/authors/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAuthor(int id, [FromBody] Author updatedAuthor)
        {
            if (updatedAuthor == null || id != updatedAuthor.AuthorId)
            {
                return BadRequest("Author data is invalid.");
            }

            var existingAuthor = await _authorService.GetByIdAsync(id);
            if (existingAuthor == null)
            {
                return NotFound();
            }

            // Update fields of the existing author
            existingAuthor.Name = updatedAuthor.Name;
            existingAuthor.Country = updatedAuthor.Country;

            _authorService.Update(existingAuthor);
            await _unitOfWork.CompleteAsync();

            return NoContent();
        }

        // DELETE: api/authors/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAuthor(int id)
        {
            var author = await _authorService.GetByIdAsync(id);
            if (author == null)
            {
                return NotFound();
            }

            _authorService.Delete(author);
            await _unitOfWork.CompleteAsync();

            return NoContent();
        }
    }
}
