using controller.Models;
using Microsoft.AspNetCore.Mvc;

namespace controller.Controllers
{
    public class CourseController : Controller
    {
        private List<Course> _courses = new List<Course>()
        {
            new() {Id=1, Name="Basic Charp", NumberOfClasses=10},
            new() {Id=1, Name="Advance Charp", NumberOfClasses=15},
            new() {Id=1, Name="ASP.NET CORE MVC", NumberOfClasses=10},
            new() {Id=1, Name="ASP.NET CORE WEB API", NumberOfClasses=10},

         };


        public JsonResult GetAllCourses()
        {
            return Json(_courses);
        }

        public IActionResult GetCourseById(int id)
        {
            return Json(_courses.FirstOrDefault(course => course.Id == id));
        }

    }
}
