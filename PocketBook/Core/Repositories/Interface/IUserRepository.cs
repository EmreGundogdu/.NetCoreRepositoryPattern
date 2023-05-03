using PocketBook.Models;

namespace PocketBook.Core.Repositories.Interface
{
    public interface IUserRepository : IGenericRepository<User>
    {
        Task<string> GetFirstNameAndLastName(Guid id);
    }
}
