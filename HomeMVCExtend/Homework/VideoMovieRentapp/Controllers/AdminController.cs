using Microsoft.AspNetCore.Mvc;
using VideoMovieRent.Filters;
using VideoMovieRent.Services.Dtos;
using VideoMovieRent.Services.Interfaces;
using VideoMovieRent.Services.Services.Interfaces;

namespace VideoMovieRentapp.Controllers
{
    public class AdminController : Controller
    {
        private readonly IAdminService _adminService;
        private readonly IMovieService _movieService;

        public AdminController(IMovieService movieService, IAdminService adminService)
        {
            _movieService = movieService;
            _adminService = adminService;
        }

        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(string username, string password)
        {
            if (_adminService.Login(username, password))
            {
                return RedirectToAction("Index");
            }

            ViewBag.Error = "Invalid admin credentials.";
            return View();
        }
        [AdminAuthorize]
        public IActionResult Index()
        {
            var movies = _movieService.GetAllMovies();
            return View(movies);
        }
        [AdminAuthorize]
        public IActionResult Create() => View();

        [HttpPost]
        [AdminAuthorize]
        public IActionResult Create(MovieDto dto)
        {
            _adminService.CreateMovie(dto);
            return RedirectToAction("Index");
        }
        [AdminAuthorize]
        public IActionResult Edit(int id)
        {
            var movie = _movieService.GetMovieDetails(id);
            if (movie == null)
            {
                return NotFound();
            }
            return View(movie);
        }

        [HttpPost]
        [AdminAuthorize]
        public IActionResult Edit(MovieDetailsDto dto)
        {
            _adminService.UpdateMovie(dto);
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            _adminService.DeleteMovie(id);
            return RedirectToAction("Index");
        }
    }
}
