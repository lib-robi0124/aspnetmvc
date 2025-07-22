using Microsoft.AspNetCore.Mvc;

namespace RentalMovie.Controllers
{
    public class RentalController : Controller
    {
        private readonly IRentalService _rentalService
        public IActionResult Index()
        {
            return View();
        }
    }
}
