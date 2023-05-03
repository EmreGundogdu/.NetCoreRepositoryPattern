using PocketBook.Core.IConfiguration;
using PocketBook.Core.Repositories.Interface;
using PocketBook.Data;

namespace PocketBook.Core.Repositories.Concrete
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly AppDbContext context;
        private readonly ILogger logger;

        public UnitOfWork(AppDbContext context, ILoggerFactory logger)
        {
            this.context = context;
            this.logger = logger.CreateLogger("logs");

            Users = new UserRepository(context, this.logger);
        }

        public IUserRepository Users { get; private set; }

        public async Task CompleteAsync()
        {
            await context.SaveChangesAsync();
        }
        public async void Dispose()
        {
            context.Dispose();
        }

        public async Task DisposeAsync()
        {
            await context.DisposeAsync();
        }
    }
}
