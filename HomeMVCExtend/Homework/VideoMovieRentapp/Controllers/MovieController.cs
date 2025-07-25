using Microsoft.AspNetCore.Mvc;
using VideoMovieRent.Services.Dtos;
using VideoMovieRent.Services.Interfaces;

namespace VideoMovieRentapp.Controllers
{
    public class MovieController : Controller
    {
        private readonly IMovieService _movieService;           // Handles movie-related operations
        private readonly IRentalService _rentalService;         // Handles renting and returning of movies
        private readonly IUserService _userService;             // Used to find users by card number
        private readonly IWebHostEnvironment _webHostEnvironment; // Used to get the wwwroot path for saving images
        public MovieController(
            IMovieService movieService,
            IRentalService rentalService,
            IUserService userService,
            IWebHostEnvironment webHostEnvironment)
        {
            _movieService = movieService;
            _rentalService = rentalService;
            _userService = userService;
            _webHostEnvironment = webHostEnvironment;
        }
        // Display list of movies
        public IActionResult Index(int userId, int managerId)
        {
            List<MovieDto> movies = _movieService.GetAllMovies().ToList();
            ViewBag.UserId = userId;           // Used in view to know if a user is logged in
            return View(movies);               // Pass movies to the view
        }
        // GET: Show user login form
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        // POST: Handle user login by card number
        [HttpPost]
        public IActionResult Login(string cardNumber)
        {
            var user = _userService.GetUserByCardNumber(cardNumber);
            if (user == null)
            {
                ViewBag.Error = "Invalid card number.";
                return View(); // Show error if card number not found
            }
            return RedirectToAction("Index", new { userId = user.Id }); // Login success
        }
        // POST: Logout user or manager and reset state
        [HttpPost]
        public IActionResult Logout()
        {
            return RedirectToAction("Index", new { userId = 0 }); // Return to base state
        }
        // Show movie details page for user or manager
        public IActionResult Details(int id, int userId)
        {
            MovieDetailsDto movieDets = _movieService.GetMovieDetails(id);
            ViewBag.UserId = userId;
            return View(movieDets); // Show detailed info
        }
        // POST: Rent a movie for the user
        [HttpPost]
        public IActionResult Rent(int movieId, int userId)
        {
            var success = _rentalService.RentMovie(movieId, userId);
            if (!success)
            {
                TempData["Error"] = "Movie is not available for rent."; // Show error
            }
            return RedirectToAction("Details", new { id = movieId, userId });
        }
        // Show all active rentals for a user
        public IActionResult Return(int userId)
        {
            var rentals = _rentalService.GetRentalsByUserId(userId);
            ViewBag.UserId = userId;
            return View(rentals); // Show list of rented movies to return
        }
        // POST: Return a movie
        [HttpPost]
        public IActionResult ReturnMovie(int rentalId, int userId)
        {
            _rentalService.MarkAsReturned(rentalId, userId); // Mark rental as returned
            return RedirectToAction("Return", new { userId }); // Refresh page
        }
    }
}
