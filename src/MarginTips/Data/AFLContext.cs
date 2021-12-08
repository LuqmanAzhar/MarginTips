using Microsoft.EntityFrameworkCore;
using MarginTips.Models;

namespace MarginTips.Data
{
    public class AFLContext : DbContext
    {
        public AFLContext(DbContextOptions<AFLContext> options) : base(options)
        {
        }

        public DbSet<Team> Teams { get; set; }
        public DbSet<Game> Games { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        // This Method Overides the default names created with DbSet changing the DB
        {
            modelBuilder.Entity<Game>().ToTable("Game");
            modelBuilder.Entity<Team>().ToTable("Team");
        }
    }
}