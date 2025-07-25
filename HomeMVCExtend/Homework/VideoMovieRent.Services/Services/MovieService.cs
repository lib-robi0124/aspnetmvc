using VideoMovieRent.DataAccess.Interfaces;
using VideoMovieRent.Domain;
using VideoMovieRent.Services.Dtos;
using VideoMovieRent.Services.Interfaces;

namespace VideoMovieRent.Services.Services
{
    public class MovieService : IMovieService
    {
        private readonly IRepository<Movie> _movieRepository;
        public MovieService(IRepository<Movie> movieRepository)
        {
            _movieRepository = movieRepository;
        }

        public IEnumerable<MovieDto> GetAllMovies()
        {
            var movieDto = new List<MovieDto>();
            List<Movie> movies = _movieRepository.GetAll().ToList();
            if (movies != null && movies.Count > 0)
            {
                foreach (var movie in movies)
                {
                    movieDto.Add(new MovieDto
                    {
                        Id = movie.Id,
                        Title = movie.Title,
                        Genre = movie.Genre,
                        IsAvailable = movie.Quantity > 0,
                        ImagePath = movie.ImagePath
                    });
                }
                return movieDto;
            }
            return movieDto;
           
        }

        // Replace the GetById method with the correct return type and logic
        public Movie GetById(int id)
        {
            return _movieRepository.GetById(id);
          
        }

        public MovieDetailsDto GetMovieDetails(int id)
        {
            var movie = _movieRepository.GetById(id);
            if (movie != null)
            {
                var movieDetails = new MovieDetailsDto
                {
                    Id = movie.Id,
                    Title = movie.Title,
                    Genre = movie.Genre,
                    Length = movie.Length,
                    AgeRestriction = movie.AgeRestriction,
                    Quantity = movie.Quantity,
                    ReleaseDate = movie.ReleaseDate,
                    Language = movie.Language,
                    ImagePath = movie.ImagePath
                };
                return movieDetails;
            }
            else
            {
                throw new KeyNotFoundException($"Movie with ID {id} not found.");
            }
        }
      
    }
}
