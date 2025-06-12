using controller.Models;
using Microsoft.AspNetCore.Mvc;

namespace controller.Controllers
{
    public class CourseController : Controller
    {
        private List<Course> _courses = new List<Course>()
        {
            new() {Id=1, Name="Basic Charp", NumberOfClasses=10},
            new() {Id=2, Name="Advance Charp", NumberOfClasses=15},
            new() {Id=3, Name="ASP.NET CORE MVC", NumberOfClasses=10},
            new() {Id=4, Name="ASP.NET CORE WEB API", NumberOfClasses=10},

         };


        public JsonResult GetAllCourses()
        {
            return Json(_courses);
        }

        [HttpGet] //localhost:port/course/getallcourses
        public IActionResult GetCourseById(int id)
        {
           return Json(_courses.SingleOrDefault(x => x.Id == id));

        }
        public IActionResult GetCourseByIdOrName(int id, string name)
        {
            Course course = _courses.FirstOrDefault(x => x.Id == id);

            if (course == null)
            {
                course = _courses.FirstOrDefault(y => y.Name == name);
                if (course == null) return NoContent();

                return Json(course);
            }
            else
            {
                return Json(course);
            }
        }
    }
}
