using Microsoft.AspNetCore.Mvc;

namespace controller.Controllers
{
    public class CourseController : Controller
    {
        public IActionResult Index()
        {
            return View("Privacy");
        }
    }
}
