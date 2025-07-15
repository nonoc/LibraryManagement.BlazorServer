using LibraryManagement.BlazorServer.Models;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagement.BlazorServer.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options)
        : base(options)
        {
        }

        public DbSet<Book> Books => Set<Book>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Book>(entity =>
            {
                entity.HasKey(b => b.BookId);
                entity.Property(b => b.Price).HasPrecision(18, 2);
            });
        }
    }
}
