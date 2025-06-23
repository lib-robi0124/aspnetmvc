using Class04.DataBase;
using Class04.Models.DtoModels;
using Microsoft.AspNetCore.Mvc;

namespace Class04.Controllers
{
    [Route("courses")]

    public class CourseController : Controller
    {
     
        public IActionResult Index()
        {
           var courses = InMemoryDb.Courses;
            var coursesList = new List<CoursesWithStudentsDTO>();

            foreach (var course in courses)
            {
                var students = InMemoryDb.Students
                    .Where(student => student.ActiveCourse.Id == course.Id)
                    .Select(student => new StudentDTO
                    {
                        FullName = student.FirstName + " " + student.LastName
                    });

                coursesList.Add(new CoursesWithStudentsDTO
                {
                    Id = course.Id,
                    Name = course.Name,
                    Students = students.ToList()
                });
            }
            return View(coursesList);
        }
    }
}
