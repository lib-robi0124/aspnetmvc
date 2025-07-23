using Microsoft.AspNetCore.Mvc;
using RentalMovie.Services.Services.Interfaces;
using RentalMovie.Services.ViewModels;

namespace RentalMovie.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUserService _userService;

        public AccountController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var user = _userService.GetUserByCardNumber(model.CardNumber);
            if (user == null)
            {
                ModelState.AddModelError("", "Invalid Card Number.");
                return View(model);
            }

            HttpContext.Session.SetInt32("UserId", user.Id); // Ensure session is configured in Startup.cs
            return RedirectToAction("Index", "Movie", new { userId = user.Id });
        }
    }
}
