using VideoMovieRent.Domain;
using VideoMovieRent.Services.Dtos;

namespace VideoMovieRent.Services.Interfaces
{
    public interface IMovieService
    {
        IEnumerable<MovieDto> GetAllMovies();
        MovieDetailsDto GetMovieDetails(int id);
        Movie GetById(int id);
        void CreateMovie(MovieDto dto);
        void UpdateMovie(MovieDetailsDto dto);
        void DeleteMovie(Movie movie);

    }
}
