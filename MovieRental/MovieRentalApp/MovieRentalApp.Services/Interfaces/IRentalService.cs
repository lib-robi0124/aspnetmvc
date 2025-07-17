using MovieRentalApp.Dtos;

namespace MovieRentalApp.Services.Interfaces
{
    public interface IRentalService
    {
        void RentMovie(int userId, int movieId);
        void ReturnMovie(int userId, int movieId);
        List<RentalDto> GetRentedMovies(int userId);
    }
}
