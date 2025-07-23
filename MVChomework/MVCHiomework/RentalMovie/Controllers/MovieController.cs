using Microsoft.AspNetCore.Mvc;
using RentalMovie.Services.Dtos;
using RentalMovie.Services.Services.Interfaces;
using RentalMovie.Services.ViewModels;

namespace RentalMovie.Controllers
{
    public class MovieController : Controller
    {
        private readonly IMovieService _movieService;

        public MovieController(IMovieService movieService)
        {
            _movieService = movieService;
        }

        public IActionResult Index(int userId)
        {
            var movies = _movieService.GetAllMovies().ToList();
            var viewModel = new MovieListViewModel
            {
                UserId = userId,
                Movies = movies
            };
            return View(viewModel);
        }

        public IActionResult Details(int id, int userId)
        {
            var movie = _movieService.GetMovieDetails(id);
            var viewModel = new MovieDetailsViewModel
            {
                Movie = movie,
                UserId = userId
            };
            return View(viewModel);
        }
    }
}
