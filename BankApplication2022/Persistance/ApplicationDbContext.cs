using Domain.entities;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Persistance
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext()
        {
        }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
          : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            if (!options.IsConfigured)
            {
                options.UseSqlite("A FALLBACK CONNECTION STRING");
            }
            options.UseSqlite(@"Data Source=SqliteBankExalt.db");

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Account> Account { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<Transaction> Transaction { get; set; }

    }
}
