using RentalMovie.Domain;

namespace RentalMovie.Database.Interfaces
{
    public interface IMovieRepository : IRepository<Movie>
    {
        IEnumerable<Movie> GetAvailableMovies();
        Movie GetById(int id);
        void Add(Movie entity);
        void Update(Movie entity);
        void Delete(int id);
        IEnumerable<Movie> GetAll();
    }
}
