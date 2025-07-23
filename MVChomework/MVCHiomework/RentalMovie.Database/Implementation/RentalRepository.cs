using RentalMovie.Database.Interfaces;
using RentalMovie.Domain;

namespace RentalMovie.Database.Implementation
{
    public class RentalRepository : IRentalRepository
    {
        private readonly RentalMovieDbContext _db;
        public RentalRepository(RentalMovieDbContext db)
        {
            _db = db;
        }
        public IEnumerable<Rental> GetRentalsByUserId(int userId)
        {
            return _db.Rentals.Where(r => r.UserId == userId && r.ReturnedOn == DateTime.MinValue).ToList();
        }

        public bool MarkAsReturned(int rentalId, int userId)
        {
            var rental = _db.Rentals.FirstOrDefault(r => r.Id == rentalId && r.UserId == userId && r.ReturnedOn == DateTime.MinValue);
            if (rental == null)
            {
                return false; // Rental not found or already returned
            }
            rental.ReturnedOn = DateTime.UtcNow;
            var movie = _db.Movies.FirstOrDefault(m => m.Id == rental.MovieId);
            if (movie != null)
            {
                movie.Quantity++; // Increment the quantity of the movie
                if (movie.Quantity > 0)
                {
                    movie.IsAvailable = true; // Mark the movie as available
                }
                    
            }
            _db.SaveChanges();
            return true; // Rental marked as returned successfully
        }

        public bool RentMovie(int movieId, int userId)
        {
            var movie = _db.Movies.FirstOrDefault(m => m.Id == movieId && m.IsAvailable);
            if (movie == null || movie.Quantity <= 0)
            {
                return false; // Movie not available for rent
            }
            var rental = new Rental
            {
                MovieId = movieId,
                UserId = userId,
                RentedOn = DateTime.UtcNow,
                ReturnedOn = DateTime.MinValue // Not returned yet
            };
            _db.Rentals.Add(rental);
            movie.Quantity--; // Decrement the quantity of the movie
            if (movie.Quantity == 0)
            {
                movie.IsAvailable = false; // Mark the movie as not available
            }
            _db.SaveChanges();
            return true; // Rental created successfully
        }
 
    }
}
