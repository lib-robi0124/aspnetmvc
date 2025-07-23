using RentalMovie.Domain;

namespace RentalMovie.Services.Services.Interfaces
{
    public interface IRentalService
    {
        bool RentMovie(int userId, int movieId);
        bool ReturnMovie(int userId, int movieId);
        List<Rental> GetRentedMoviesByUser(int userId);
    }
}
