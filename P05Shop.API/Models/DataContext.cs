using Microsoft.EntityFrameworkCore;
using P06.Shared.Books;
using P07Book.DataSeeder;
using P06Shop.Shared.Auth;

namespace P05Shop.API.Models
{
    public class DataContext : DbContext
    {

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<Book> Books { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>()
                .Property(p => p.Id )
                .IsRequired()
                .HasColumnType("decimal(8,0)");

            modelBuilder.Entity<Book>()
                .Property(p => p.Title)
                .IsRequired()
                .HasMaxLength(100);

            modelBuilder.Entity<Book>()
                .Property(p => p.Author)
                .HasMaxLength(100);


            modelBuilder.Entity<Book>().HasData(BookSeeder.GenerateBookData());
        }
    }
}
