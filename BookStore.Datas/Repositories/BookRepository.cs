using BookStore.Datas.Data;
using BookStore.Models.Models;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Datas.Repositories;

public class BookRepository : IBookRepository
{
    private readonly BookstoreContext _context;

    public BookRepository(BookstoreContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Book>> GetBooks(int? authorId, DateTime? publishYear, int page, int pageSize)
    {
        var query = _context.Books.AsQueryable();

        if (authorId.HasValue)
            query = query.Where(b => b.AuthorId == authorId.Value);

        if (publishYear.HasValue)
            query = query.Where(b => b.PublishDate.Year == publishYear.Value.Year);

        return await query.Skip((page - 1) * pageSize).Take(pageSize).ToListAsync();
    }

    public async Task<Book> GetByIdAsync(int id)
    {
        var book = await _context.Books
            .Include(b => b.Author)
            .FirstOrDefaultAsync(b => b.BookId == id);
        return book;
    }

    public async Task<IEnumerable<Book>> GetAllAsync()
    {
        return await _context.Books
            .Include(b => b.Author)
            .ToListAsync();
    }

    public async Task AddAsync(Book book)
    {
        await _context.Books.AddAsync(book);
    }

    public void Update(Book book)
    {
        _context.Books.Update(book);
    }

    public void Delete(Book book)
    {
        _context.Books.Remove(book);
    }

    public async Task<IEnumerable<Book>> GetBooksByAuthorIdAsync(int authorId)
    {
        return await _context.Books
            .Where(b => b.AuthorId == authorId)
            .ToListAsync();
    }
}
