using RentalMovie.Database.Interfaces;
using RentalMovie.Domain;

namespace RentalMovie.Database.Implementation
{
    public class MovieRepository : IMovieRepository
    {
        private readonly RentalMovieDbContext _db;

        public MovieRepository(RentalMovieDbContext db)
        {
            _db = db;
        }
        public IEnumerable<Movie> GetAll()
        {
            return _db.Movies.ToList();
        } 
        public Movie GetById(int id)
        {
            return _db.Movies.SingleOrDefault(x => x.Id == id);
        }
        public void Add(Movie entity)
        {
            _db.Movies.Add(entity);
            _db.SaveChanges();
        }
        public void Delete(int id)
        {
            var movie = _db.Movies.SingleOrDefault(x => x.Id == id);

            if (movie != null)
            {
                _db.Movies.Remove(movie);
                _db.SaveChanges();
            }
        }
        public void Update(Movie entity)
        {
            _db.Movies.Update(entity);
            _db.SaveChanges();
        }
    }
}
