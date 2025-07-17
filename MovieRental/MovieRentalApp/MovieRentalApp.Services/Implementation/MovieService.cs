using MovieRentalApp.Database;
using MovieRentalApp.Domain;
using MovieRentalApp.Services.Interfaces;

namespace MovieRentalApp.Services.Implementation
{
    public class MovieService : IMovieService
    {
        //private readonly AppDbContext _context;
        //public MovieService(AppDbContext context) => _context = context;

        //public IEnumerable<Movie> GetAll() => _context.Movies.ToList();
        //public Movie GetById(int id) => _context.Movies.Find(id);
        //public List<Movie> GetAll()
        //{
        //    return StaticDb.Movies;
        //}

        public Movie GetById(int id)
        {
            return StaticDb.Movies.FirstOrDefault(m => m.Id == id);
        }

        IEnumerable<Movie> IMovieService.GetAll()
        {
            return StaticDb.Movies;
        }
    }
}
