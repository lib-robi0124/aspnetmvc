using Microsoft.EntityFrameworkCore;
using RentalMovie.Domain;

namespace RentalMovie.Database
{
    public class RentalMovieDbContext(DbContextOptions<RentalMovieDbContext> options) : DbContext(options)
    {
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
