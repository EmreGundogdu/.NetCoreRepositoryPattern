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
                return new List<User>();
            }
        }
        public override async Task<bool> Upsert(User entity)
        {
            try
            {
                var existingUser = await dbSet.Where(x => x.Id == entity.Id).FirstOrDefaultAsync();
                if (existingUser != null)
                {
                    existingUser.FirstName = entity.FirstName;
                    existingUser.LastName = entity.LastName;
                    existingUser.Email = entity.Email;
                    return true;
                }
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "{Repo} upsert method error", typeof(UserRepository));
                return false;
            }
            return await Add(entity);
        }
        public async override Task<bool> Delete(Guid id)
        {
            try
            {
                var existingUser = await dbSet.Where(x => x.Id == id).FirstOrDefaultAsync();
                if (existingUser is not null)
                {
                    dbSet.Remove(existingUser);
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "{Repo} delete method error", typeof(UserRepository));
                return false;
            }
        }
    }
}
