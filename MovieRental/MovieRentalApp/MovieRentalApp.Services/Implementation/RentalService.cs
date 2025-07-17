using MovieRentalApp.Database;
using MovieRentalApp.Domain;
using MovieRentalApp.Dtos;
using MovieRentalApp.Services.Interfaces;

namespace MovieRentalApp.Services.Implementation
{
    public class RentalService : IRentalService
    {
        //private readonly AppDbContext _context;
        //public RentalService(AppDbContext context) => _context = context;

        public void RentMovie(int userId, int movieId)
        {
            var movie = StaticDb.Movies.FirstOrDefault(m => m.Id == movieId);
            if (movie == null || movie.Quantity <= 0) return;

            movie.Quantity--;
            // Assuming StaticDb is a static class that holds the in-memory data
            var newRental = new Rental
            {
                Id = StaticDb.Rentals.Count + 1,
                UserId = userId,
                MovieId = movieId,
                RentedOn = DateTime.Now
            };

            StaticDb.Rentals.Add(newRental);
        }

        public void ReturnMovie(int userId, int movieId)
        {
            var rental = StaticDb.Rentals
                .FirstOrDefault(r => r.UserId == userId && r.MovieId == movieId && r.ReturnedOn == null);

            if (rental == null) return;

            rental.ReturnedOn = DateTime.Now;

            var movie = StaticDb.Movies.FirstOrDefault(m => m.Id == movieId);
            if (movie != null) movie.Quantity++;
        }

        public List<RentalDto> GetRentedMovies(int userId)
        {
            var rentals = StaticDb.Rentals
                 .Where(r => r.UserId == userId && r.ReturnedOn == null)
                 .ToList();

            var result = rentals
                .Join(StaticDb.Movies,
                      rental => rental.MovieId,
                      movie => movie.Id,
                      (rental, movie) => new RentalDto
                      {
                          MovieTitle = movie.Title,
                          RentedOn = rental.RentedOn,
                          ReturnedOn = rental.ReturnedOn
                      })
                .ToList();

            return result;
        }
    }

}
