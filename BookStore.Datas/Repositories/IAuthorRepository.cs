using BookStore.Models.Models;

namespace BookStore.Datas.Repositories;

public interface IAuthorRepository
{
    Task<IEnumerable<Author>> GetAllAuthors();
    Task<Author> GetByIdAsync(int id);
    Task AddAsync(Author author);
    void Update(Author author);
    void Delete(Author author);
}
