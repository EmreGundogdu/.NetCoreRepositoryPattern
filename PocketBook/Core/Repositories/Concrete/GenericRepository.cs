using Microsoft.EntityFrameworkCore;
using PocketBook.Core.Repositories.Interface;
using PocketBook.Data;

namespace PocketBook.Core.Repositories.Concrete
{
    public class GenericRepository<X> : IGenericRepository<X> where X : class
    {
        protected AppDbContext context;
        protected DbSet<X> dbSet;
        protected readonly ILogger logger;
        public GenericRepository(AppDbContext context, ILogger logger)
        {
            this.context = context;
            this.logger = logger;
        }

        public async Task<bool> Add(X entity)
        {
            await dbSet.AddAsync(entity);
            return true;
        }

        public async Task<IEnumerable<X>> All()
        {
            return await dbSet.ToListAsync();
        }

        public async Task<bool> Delete(Guid id)
        {
            var data = await dbSet.FindAsync(id);
            dbSet.Remove(data);
            return true;
        }

        public async Task<X> GetById(Guid id)
        {
            return await dbSet.FindAsync(id);
        }

        public Task<bool> Upsert(X entity)
        {
            throw new NotImplementedException();
        }
    }
}
