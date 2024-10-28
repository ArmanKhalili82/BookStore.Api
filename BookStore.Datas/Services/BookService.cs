using BookStore.Datas.UnitOfWork;
using BookStore.Models.Models;

namespace BookStore.Datas.Services;

public class BookService
{
    private readonly IUnitOfWork _unitOfWork;

    public BookService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<Book>> GetBooks(int? authorId, DateTime? publishYear, int page, int pageSize)
    {
        return await _unitOfWork.Books.GetBooks(authorId, publishYear, page, pageSize);
    }

    public async Task<Book> GetByIdAsync(int id)
    {
        var book = await _unitOfWork.Books.GetByIdAsync(id);
        return book;
    }

    public async Task<IEnumerable<Book>> GetAllAsync()
    {
        var books = await _unitOfWork.Books.GetAllAsync();
        return books;
    }

    public async Task AddAsync(Book book)
    {
        await _unitOfWork.Books.AddAsync(book);
    }

    public void Update(Book book)
    {
        _unitOfWork.Books.Update(book);
    }

    public void Delete(Book book)
    {
        _unitOfWork.Books.Delete(book);
    }

    public async Task<IEnumerable<Book>> GetBooksByAuthorIdAsync(int authorId)
    {
        var books = await _unitOfWork.Books.GetBooksByAuthorIdAsync(authorId);
        return books;
    }
}
