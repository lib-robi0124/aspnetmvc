using Microsoft.AspNetCore.Mvc;
using TodoApp.Services.Dtos;
using TodoApp.Services.Services.Interfaces;
using TodoApp.Web.Models;

namespace TodoApp.Web.Controllers
{
    //[Route("")]
    public class TodoController : Controller
    {
        private readonly ITodoService _todoService;
        private readonly ICategoryServices _categoryServices;
        public TodoController(ITodoService todoService, ICategoryServices categoryServices)
        {
            _todoService = todoService;
            _categoryServices = categoryServices;
        }
        public IActionResult Index()
        {
            List<TodoDto> todos = _todoService.GetAllTodos().ToList();
            return View(todos);
        }
        [HttpGet]
        public IActionResult Create()
        {
            CreateTodoVm createTodoVM = new CreateTodoVm();
            createTodoVM.Categories = _categoryServices.GetAllCategories();
            createTodoVM.DueDate = DateTime.Now;
            return View(createTodoVM);
        }
        [HttpPost]
        public IActionResult Create(CreateTodoVm model)
        {
            if (ModelState.IsValid)
            {
                _todoService.AddTodo(model);
                return RedirectToAction("Index");
            }
            return View(model);

        }
        [HttpPost]
        public IActionResult MarkComplete(int todoId)
        {
            var response = _todoService.MarkComplete(todoId);
            if(!response)
            {
                //TempData["Erromsg"] = "Todo does not exist";
                ViewBag.ErrorMessage = "Todo does not exist";
            }
            return RedirectToAction("Index");

        }
        [HttpPost]
        public IActionResult RemoveComplete()
        {
            _todoService.RemoveComplete();
            return RedirectToAction("Index");
        }
    }
}
