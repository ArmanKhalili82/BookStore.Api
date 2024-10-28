using BookStore.Datas.Data;
using BookStore.Datas.Repositories;

namespace BookStore.Datas.UnitOfWork;

public class UnitOfWork : IUnitOfWork
{
    private readonly BookstoreContext _context;
    public IBookRepository Books { get; }
    public IAuthorRepository Authors { get; }

    public UnitOfWork(BookstoreContext context, IBookRepository bookRepository, IAuthorRepository authorRepository)
    {
        _context = context;
        Books = bookRepository;
        Authors = authorRepository;
    }

    public async Task CompleteAsync()
    {
        await _context.SaveChangesAsync();
    }
}
