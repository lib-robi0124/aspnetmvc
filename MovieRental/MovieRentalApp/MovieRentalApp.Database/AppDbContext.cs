using Microsoft.EntityFrameworkCore;
using MovieRentalApp.Domain;

namespace MovieRentalApp.Database
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Rental> Rentals { get; set; }
        public DbSet<Cast> Casts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>()
                .HasData(StaticDb.Users);

            modelBuilder.Entity<Movie>()
                .HasData(StaticDb.Movies);

            modelBuilder.Entity<Rental>()
                .HasData(StaticDb.Rentals);

            modelBuilder.Entity<Cast>()
                .HasData(StaticDb.Casts);
        }
    }
}
