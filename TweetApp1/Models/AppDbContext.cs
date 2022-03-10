using Microsoft.EntityFrameworkCore;

namespace TweetApp.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }
        public DbSet<User> User { get; set; }
        public DbSet<Tweet> Tweet { get; set; }
    }
}
