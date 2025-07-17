using Microsoft.AspNetCore.Mvc;
using MovieRentalApp.Services.Interfaces;

namespace MovieRentalApp.Web.Controllers
{
    public class RentalController : Controller
    {
        private readonly IRentalService _rentalService;

        public RentalController(IRentalService rentalService) => _rentalService = rentalService;

        public IActionResult MyRentals()
        {
            var userId = HttpContext.Session.GetInt32("UserId");
            if (userId == null) return RedirectToAction("Login", "User");

            var rentals = _rentalService.GetRentedMovies(userId.Value);
            return View(rentals);
        }

        public IActionResult Rent(int movieId)
        {
            var userId = HttpContext.Session.GetInt32("UserId");
            if (userId == null) return RedirectToAction("Login", "User");

            _rentalService.RentMovie(userId.Value, movieId);
            return RedirectToAction("Index", "Movie");
        }

        public IActionResult Return(int movieId)
        {
            var userId = HttpContext.Session.GetInt32("UserId");
            if (userId == null) return RedirectToAction("Login", "User");

            _rentalService.ReturnMovie(userId.Value, movieId);
            return RedirectToAction("MyRentals");
        }
    }
}
