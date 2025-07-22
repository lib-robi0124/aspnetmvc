using Microsoft.AspNetCore.Mvc;

namespace RentalMovie.Controllers
{
    public class MovieController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
