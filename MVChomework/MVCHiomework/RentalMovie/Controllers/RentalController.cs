using Microsoft.AspNetCore.Mvc;

namespace RentalMovie.Controllers
{
    public class RentalController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
