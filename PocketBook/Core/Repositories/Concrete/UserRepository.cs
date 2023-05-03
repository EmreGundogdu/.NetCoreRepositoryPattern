using Microsoft.EntityFrameworkCore;
using PocketBook.Core.Repositories.Interface;
using PocketBook.Data;
using PocketBook.Models;

namespace PocketBook.Core.Repositories.Concrete
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(AppDbContext context, ILogger logger) : base(context, logger)
        {
        }

        public Task<string> GetFirstNameAndLastName(Guid id)
        {
            throw new NotImplementedException();
        }
        public override async Task<IEnumerable<User>> All()
        {
            try
            {
                return await dbSet.ToListAsync();
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "{Repo} all method error", typeof(UserRepository));
                return new List<User();
            }
        }
    }
}
