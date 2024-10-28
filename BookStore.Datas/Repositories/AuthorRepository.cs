using BookStore.Datas.Data;
using BookStore.Models.Models;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Datas.Repositories;

public class AuthorRepository : IAuthorRepository
{
    private readonly BookstoreContext _context;

    public AuthorRepository(BookstoreContext context)
    {
        _context = context;
    }

    public async Task<Author> GetByIdAsync(int id)
    {
        return await _context.Authors
            .Include(a => a.Books) // Include related books if needed
            .FirstOrDefaultAsync(a => a.AuthorId == id);
    }

    public async Task<IEnumerable<Author>> GetAllAuthors()
    {
        return await _context.Authors
            .Include(a => a.Books) // Optionally include related books
            .ToListAsync();
    }

    public async Task AddAsync(Author author)
    {
        await _context.Authors.AddAsync(author);
    }

    public void Update(Author author)
    {
        _context.Authors.Update(author);
    }

    public void Delete(Author author)
    {
        _context.Authors.Remove(author);
    }
}
