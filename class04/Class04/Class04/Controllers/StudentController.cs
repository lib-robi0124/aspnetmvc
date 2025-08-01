﻿using Class04.Models.DtoModels;
using Class04.Models.ViewModels;
using Class04.Services;
using Microsoft.AspNetCore.Mvc;


namespace Class04.Controllers
{
    //[Route("students")]
    [Route("[Controller]")]
    public class StudentController : Controller
    {
        private readonly StudentService _studentService;

        public StudentController()
        {
            _studentService = new StudentService();
        }

        //[HttpGet("getAllStudents")]
        public IActionResult GetAllStudents()
        {
            List<StudentWithCourseDto> students = _studentService.GetAllStudents();

            return View(students);
        }

        [HttpGet("{id}")]
        public IActionResult GetStudentById(int id)
        {
            StudentWithCourseDto student = _studentService.GetStudentById(id);

            if (student == null)
            {
                return RedirectToAction($"Student with ID {id} not found.", "Home");
            }
            return View(student);
        }
        [HttpGet("createStudent")]
        public IActionResult CreateStudent()
        {
            return View();
        }
        [HttpPost("createStudent")]
        public IActionResult CreateStudent(CreateStudentVM createStudentVM)
        {
            _studentService.CreateStudent(createStudentVM);
            return RedirectToAction("GetAllStudents");
        }

    }
}

