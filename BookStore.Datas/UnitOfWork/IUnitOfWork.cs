using BookStore.Datas.Repositories;

namespace BookStore.Datas.UnitOfWork
{
    public interface IUnitOfWork
    {
        IBookRepository Books { get; }
        IAuthorRepository Authors { get; }
        Task CompleteAsync();
    }
}
