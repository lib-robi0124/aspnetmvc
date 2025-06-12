using controller.Models;
using Microsoft.AspNetCore.Mvc;

namespace controller.Controllers
{
    [Route("students")]
    //[Route("students/[Action]")]

    public class StudentController : Controller
    {

        private List<Student> _students = new List<Student>()
        {
                new()
            {
                Id = 1,
                FirstName = "Bob",
                LastName = "Bobski",
            },
            new()
            {
                Id = 2,
                FirstName = "Jill",
                LastName = "Jilski",
            },
            new()
            {
                Id = 3,
                FirstName = "John",
                LastName = "Doe",
            }
        };

        [Route("getAllStudents")]
        public IActionResult GetAll()
        {
            return Json(_students);
        }

        [HttpGet("getAll")]
        public IActionResult GetStudents() { return Json(_students); }

        [HttpGet("getStudentById/{id}")]
        public Student GetStudentById(int id)
        {
            return _students.SingleOrDefault(x => x.Id == id);
        }
        [HttpGet("{id}")]//not good practise 
        public Student GetById(int id)
        {
            return _students.SingleOrDefault(x => x.Id == id);
        }

        [HttpGet("getStudentByIdWithConstraint/{id:int}")]
        public Student GetStudentByIdWithConstraint(int id)
        {
            return _students.SingleOrDefault(x => x.Id == id);
        }
        }
    }
