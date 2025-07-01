using Microsoft.AspNetCore.Mvc;
using TodoApp.Services.Dtos;
using TodoApp.Services.Services;
using TodoApp.Services.Services.Interfaces;
using TodoApp.Web.Models;

namespace TodoApp.Web.Controllers
{
    [Route("")]
    public class TodoController : Controller
    {
        private readonly ITodoService _todoService;
        public TodoController (ITodoService todoService)
        {
            _todoService = todoService;
        }
        public IActionResult Index()
        {
            List<TodoDto> todos = _todoService.GetAllTodos().ToList();
            return View(todos);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(CreateTodoVm model) {

    }
}
