using BookStore.Models.Models;

namespace BookStore.Datas.Repositories;

public interface IBookRepository
{
    Task<IEnumerable<Book>> GetBooks(int? authorId, DateTime? publishYear, int page, int pageSize);
    Task<Book> GetByIdAsync(int id);
    Task<IEnumerable<Book>> GetAllAsync();
    Task AddAsync(Book book);
    void Update(Book book);
    void Delete(Book book);
    Task<IEnumerable<Book>> GetBooksByAuthorIdAsync(int authorId);
}
