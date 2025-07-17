using Microsoft.AspNetCore.Mvc;
using MovieRentalApp.Services.Interfaces;

namespace MovieRentalApp.Web.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService) => _userService = userService;

        [HttpGet]
        public IActionResult Login() => View();

        [HttpPost]
        public IActionResult Login(string cardNumber)
        {
            var user = _userService.Login(cardNumber);
            if (user != null)
            {
                HttpContext.Session.SetInt32("UserId", user.Id);
                return RedirectToAction("Index", "Movie");
            }

            ViewBag.Message = "Invalid card number";
            return View();
        }
    }
}
