using BookStore.Datas.UnitOfWork;
using BookStore.Models.Models;

namespace BookStore.Datas.Services;

public class AuthorService
{
    private readonly IUnitOfWork _unitOfWork;

    public AuthorService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<Author>> GetAllAuthors()
    {
        return await _unitOfWork.Authors.GetAllAuthors();
    }

    public async Task<Author> GetByIdAsync(int id)
    {
        var author = await _unitOfWork.Authors.GetByIdAsync(id);
        return author;
    }

    public async Task AddAsync(Author author)
    {
        await _unitOfWork.Authors.AddAsync(author);
    }

    public void Update(Author author)
    {
        _unitOfWork.Authors.Update(author);
    }

    public void Delete(Author author)
    {
        _unitOfWork.Authors.Delete(author);
    }
}
