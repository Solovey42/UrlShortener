using Microsoft.EntityFrameworkCore;

namespace API.Domain.Models
{
    public class LinksContext : DbContext
    {
        public DbSet<Link> Links { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Filename=LinksDatabase.db");
        }
        public LinksContext(DbContextOptions<LinksContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
