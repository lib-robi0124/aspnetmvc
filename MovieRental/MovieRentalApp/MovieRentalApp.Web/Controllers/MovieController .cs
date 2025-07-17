using Microsoft.AspNetCore.Mvc;
using MovieRentalApp.Services.Interfaces;

namespace MovieRentalApp.Web.Controllers
{
    public class MovieController : Controller
    {
        private readonly IMovieService _movieService;
        public MovieController(IMovieService movieService) => _movieService = movieService;

        public IActionResult Index()
        {
            var movies = _movieService.GetAll();
            return View(movies);
        }

        public IActionResult Details(int id)
        {
            var movie = _movieService.GetById(id);
            return View(movie);
        }
    }
}
