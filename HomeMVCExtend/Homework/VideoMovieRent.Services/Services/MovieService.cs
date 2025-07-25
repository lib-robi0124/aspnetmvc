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
        public void CreateMovie(MovieDto dto)
        {
            var movie = new Movie
            {
                Title = dto.Title,
                Genre = dto.Genre,
                Language = dto.Language,
                Quantity = 1, // Default quantity for new movies
                ImagePath = dto.ImagePath
            };
            _movieRepository.Create(movie);
        }

        public void UpdateMovie(MovieDetailsDto dto)
        {
            var movie = _movieRepository.GetById(dto.Id);
            if (movie == null)
            {
                throw new KeyNotFoundException($"Movie with ID {dto.Id} not found.");
            }
            movie.Title = dto.Title;
            movie.Genre = dto.Genre;
            movie.Length = dto.Length;
            movie.AgeRestriction = dto.AgeRestriction;
            movie.Quantity = dto.Quantity;
            movie.ReleaseDate = dto.ReleaseDate;
            movie.Language = dto.Language;
            movie.ImagePath = dto.ImagePath;
            // Update the movie in the repository
            _movieRepository.Update(movie);
        }

        public void DeleteMovie(Movie movie)
        {
            var dmovie = _movieRepository.GetById(movie);
            if (dmovie == null)
            {
                throw new KeyNotFoundException($"Movie with ID {movie} not found.");
            }
            // Delete the movie from the repository
            _movieRepository.Delete(movie);
        }
    }
}
