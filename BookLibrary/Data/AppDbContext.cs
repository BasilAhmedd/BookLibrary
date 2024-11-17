using BookLibrary.Models;
using Microsoft.EntityFrameworkCore;

namespace BookLibrary.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Book> books { get; set; }
        public DbSet<Author> authors { get; set; }
        public DbSet<Genre> genres { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Book>()
                .HasMany(x => x.Authors)
                .WithMany(s => s.books);

            modelBuilder.Entity<Book>()
                .HasMany(x => x.Genres)
                .WithMany(s => s.books);
        }
    }
}
