using PocketBook.Core.Repositories.Interface;

namespace PocketBook.Core.IConfiguration
{
    public interface IUnitOfWork
    {
        IUserRepository Users { get; }
        Task CompleteAsync();

    }
}
