using Class05.DataBase;
using Class05.Models.Entites;
using Class05.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Class05.Controllers
{
    public class StudentController : Controller

    {
        public IActionResult GetAllStudents()
        {
            List<StudentVM> students = InMemoryDB.Students.Select(x => new StudentVM
            {
                Id = x.Id,
                FullName = $"{x.FirstName} {x.LastName}",
                Age = DateTime.Now.Year - x.DateOfBirth.Year,
                ActiveCourseName = x.ActiveCourse.Name
            }).ToList();
            return View(students);
        }

        [HttpGet("create")]
        public IActionResult Create()
        {
            CreateStudentVM createStudentVM = new();
            //createStudentVM.FirstName = "Martin";
            //createStudentVM.LastName = "Panovski";
            createStudentVM.Courses = InMemoryDB.Courses.Select(x => new CourseOptionVM
            {
                Id = x.Id,
                Name = x.Name,
            }).ToList();
            return View(createStudentVM);
        }

        [HttpPost("create")]
        public IActionResult Create(CreateStudentVM createStudentVM)
        {
            if (!ModelState.IsValid)
            {
                createStudentVM.Courses = InMemoryDB.Courses.Select(x => new CourseOptionVM
                {
                    Id = x.Id,
                    Name = x.Name,
                }).ToList();
                return View(createStudentVM);
            }
            Student student = new()
            {
                Id = InMemoryDB.Students.Count + 1,
                FirstName = createStudentVM.FirstName,
                LastName = createStudentVM.LastName,
                DateOfBirth = createStudentVM.DateOfBirth,
                ActiveCourse = InMemoryDB.Courses.FirstOrDefault(x => x.Id == createStudentVM.ActiveCourseId)
            };
            InMemoryDB.Students.Add(student);
            return RedirectToAction("GetAllStudents");
        }
        [HttpGet("{id}")]
        public IActionResult Details(int id)
        {
            Student student = InMemoryDB.Students.SingleOrDefault(x => x.Id == id);
            if (student == null)
            {
                return NotFound();
            }
            StudentVM studentVM = new()
            {
                Id = student.Id,
                FullName = $"{student.FirstName} {student.LastName}",
                Age = DateTime.Now.Year - student.DateOfBirth.Year,
                ActiveCourseName = student.ActiveCourse?.Name ?? "No active course"
            };
            return View(studentVM);
        }
    }
}
