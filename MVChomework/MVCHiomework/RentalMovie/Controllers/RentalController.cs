using Microsoft.AspNetCore.Mvc;
using RentalMovie.Services.Services.Interfaces;
using RentalMovie.Services.ViewModels;

namespace RentalMovie.Controllers
{
    public class RentalController : Controller
    {
        private readonly IRentalService _rentalService;

        public RentalController(IRentalService rentalService)
        {
            _rentalService = rentalService;
        }

        [HttpPost]
        public IActionResult Rent(int movieId, int userId)
        {
            var result = _rentalService.RentMovie(userId, movieId);
            return RedirectToAction("Details", "Movie", new { id = movieId, userId });
        }

        [HttpGet]
        public IActionResult MyRentals(int userId)
        {
            var rentedMovies = _rentalService.GetRentedMoviesByUser(userId);
            var viewModel = new RentedMoviesViewModel
            {
                UserId = userId,
                RentedMovies = rentedMovies
            };
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Return(int rentalId, int userId)
        {
            _rentalService.ReturnMovie(userId, rentalId);
            return RedirectToAction("MyRentals", new { userId });
        }
    }
}
