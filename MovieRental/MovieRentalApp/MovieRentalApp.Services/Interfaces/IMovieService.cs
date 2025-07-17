using MovieRentalApp.Domain;

namespace MovieRentalApp.Services.Interfaces
{
    public interface IMovieService
    {
        IEnumerable<Movie> GetAll();
        Movie GetById(int id);
    }
}
