using Microsoft.AspNetCore.Mvc;
using TodoApp.Services.Dtos;
using TodoApp.Services.Services;
using TodoApp.Services.Services.Interfaces;
using TodoApp.Web.Models;

namespace TodoApp.Web.Controllers
{
    //[Route("")]
    public class TodoController : Controller
    {
        private readonly ITodoService _todoService;
        private readonly ICategoryServices _categoryService;
        public TodoController(ITodoService todoService, ICategoryServices categoryService)
        {
            _todoService = todoService;
            _categoryService = categoryService;
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
            createTodoVM.DueDate = DateTime.Now;
            createTodoVM.Categories = _categoryService.GetAllCategories();
            return View(createTodoVM);
        }
        [HttpPost]
        public IActionResult Create(CreateTodoVm model)
        {
            if (ModelState.IsValid)
            {
                if (model.CategoryId == 0)
                {
                    ModelState.AddModelError("", "Please select category!");
                    model.Categories = _categoryService.GetAllCategories();
                    return View(model);
                }
                _todoService.AddTodo(model);
                return RedirectToAction("Index");
            }
            return View(model);

        }
        [HttpPost]
        public IActionResult MarkComplete(int id)
        {
            var response = _todoService.MarkComplete(id);
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
