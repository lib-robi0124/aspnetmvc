using Microsoft.AspNetCore.Mvc;
using ModelBinding.Models.Dto;
using ModelBinding.Models.ViewModels;

namespace ModelBinding.Controllers
{
    public class StudentController : Controller
    {
        private List<StudentDto> _students;


        [HttpGet]
        public StudentController()
        {
            _students = new List<StudentDto>();
                {
                    new StudentDto
                    {
                        Id = 1,
                        FullName = "Bob Bobsky",
                        Age = 33
                    },
                    new StudentDto
                    {
                        Id = 2,
                        FullName = "Jill Jully",
                        Age = 22
                    },
                    new StudentDto
                    {
                        Id = 3,
                        FullName = "Ada Dog",
                        Age = 15
                    },
                    new StudentDto
                    {
                        Id = 4,
                        FullName = "Lia Zile",
                        Age = 42
                    }
                };

         
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View(_students);
        }
        [HttpPost]
        public IActionResult Create(CreateStudentVM model)
        {
            if (ModelState.IsValid) 
            {

                StudentDto student = new();
                {
                    Id = _students.Count + 1,
                FullName = $"{model.FirstName} {model.LastName}",
                Age = DateTime.Now.Year - model.DateOfBirth.Year;

                }
                _students.Add(student);
                return RedirectToAction("Index");
            } 
            return View();
        }

    }
}
