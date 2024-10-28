using BookStore.Datas.Data;
using BookStore.Models.Dtos;
using BookStore.Models.Models;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Datas.Services;

public class ReportingService
{
    private readonly BookstoreContext _context;

    public ReportingService(BookstoreContext context)
    {
        _context = context;
    }

    // Query 1: Authors with More Than 5 Books
    public async Task<IEnumerable<Author>> GetAuthorsWithMoreThanFiveBooks()
    {
        return await _context.Authors
            .Where(a => a.Books.Count > 5)
            .ToListAsync();
    }

    // Query 2: Average Book Price by Country
    public async Task<IEnumerable<AveragePriceByCountryDto>> GetAverageBookPriceByCountry()
    {
        return await _context.Authors
            .GroupBy(a => a.Country)
            .Select(g => new AveragePriceByCountryDto
            {
                Country = g.Key,
                AveragePrice = g.SelectMany(a => a.Books).Average(b => b.Price)
            })
            .ToListAsync();
    }

    // Query 3: Books List with Author Names, Filterable by Year
    public async Task<IEnumerable<BookWithAuthorDto>> GetBooksWithAuthorNameByYear(int year)
    {
        return await _context.Books
            .Where(b => b.PublishDate.Year == year)
            .OrderByDescending(b => b.Price)
            .Select(b => new BookWithAuthorDto
            {
                BookId = b.BookId,
                Title = b.Title,
                AuthorName = b.Author.Name,
                Price = b.Price,
                PublishDate = b.PublishDate
            })
            .ToListAsync();
    }
}
