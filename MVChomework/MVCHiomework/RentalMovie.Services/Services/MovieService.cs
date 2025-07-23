using RentalMovie.Database.Interfaces;
using RentalMovie.Domain;
using RentalMovie.Services.Dtos;
using RentalMovie.Services.Services.Interfaces;

namespace RentalMovie.Services.Services
{
    public class MovieService : IMovieService
    {
        private readonly IMovieRepository _movieService;
        public MovieService(IMovieRepository movieService)
        {
            _movieService = movieService;
        }
        public IEnumerable<MovieDto> GetAllMovies()
        {
            var movieDto = new List<MovieDto>();
            List<Movie> movies = _movieService.GetAll().ToList();
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

        public Movie GetById(int id)
        {
            return _movieService.GetById(id);
        }

        public MovieDetailsDto GetMovieDetails(int id)
        {
            var movie = _movieService.GetById(id);
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
