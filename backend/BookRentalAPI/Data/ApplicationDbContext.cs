using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;

using BookRentalAPI.Models.Entities;


namespace BookRentalAPI.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
    : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Rental> Rentals { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Relationships
            modelBuilder.Entity<Rental>()
                .HasOne(r => r.User)
                .WithMany(u => u.Rentals)
                .HasForeignKey(r => r.UserId);

            modelBuilder.Entity<Rental>()
                .HasOne(r => r.Book)
                .WithMany(b => b.Rentals)
                .HasForeignKey(r => r.BookId);
        }
    }
}
