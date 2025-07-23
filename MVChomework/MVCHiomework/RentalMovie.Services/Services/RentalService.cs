using RentalMovie.Domain;
using RentalMovie.Services.Services.Interfaces;

namespace RentalMovie.Services.Services
{
    public class RentalService : IRentalService
    {
        private readonly IRentalService _rentalService;
        public RentalService(IRentalService rentalService)
        {
            _rentalService = rentalService;
        }
        public List<Rental> GetRentedMoviesByUser(int userId)
        {
            return _rentalService.GetRentedMoviesByUser(userId);
        }

        public bool RentMovie(int userId, int movieId)
        {
            return _rentalService.RentMovie(userId, movieId);
        }

        public bool ReturnMovie(int userId, int movieId)
        {
            return _rentalService.ReturnMovie(userId, movieId);
        }
    }
}
