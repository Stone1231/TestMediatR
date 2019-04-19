using Microsoft.EntityFrameworkCore;

namespace DataAssert
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
                : base(options)
        {
        }

        public DbSet<Person> Person { get; set; }
    }
}