using Microsoft.EntityFrameworkCore;
using PocketBook.Models;

namespace PocketBook.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> dbContextOptions) : base(dbContextOptions)
        {

        }
        public virtual DbSet<User> Users { get; set; }
    }
}
