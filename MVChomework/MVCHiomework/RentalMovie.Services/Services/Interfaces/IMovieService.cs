using RentalMovie.Domain;
using RentalMovie.Services.Dtos;

namespace RentalMovie.Services.Services.Interfaces
{
    public interface IMovieService
    {
        IEnumerable<MovieDto> GetAllMovies();
        MovieDetailsDto GetMovieDetails(int id);
        Movie GetById(int id);
    }
}
