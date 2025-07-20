namespace Avenga.TodoApp.Domain
{
    public abstract class BaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
    }
}
namespace Avenga.TodoApp.Domain
{
    public class Todo : BaseEntity
    {
        [MaxLength(10)]
        public string Description { get; set; }
        public DateTime DueDate { get; set; }
        public int StatusId { get; set; }
        public Status Status { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
namespace Avenga.TodoApp.Domain
{
    public class Category : BaseEntity
    {
        public string Name { get; set; }
    }
}
namespace Avenga.TodoApp.Domain
{
    public class Status : BaseEntity
    {
        public string Name { get; set; }
    }
}
namespace Avenga.TodoApp.DataAccess
{
    public class TodoDbContext : DbContext
    {
        public TodoDbContext(DbContextOptions options) : base(options) { }
        public DbSet<Todo> Todos { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Status> Statuses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Todo>()
                .HasData(StaticDb.Todos);

            modelBuilder.Entity<Category>()
                .HasData(StaticDb.Categories);

            modelBuilder.Entity<Status>()
                .HasData(StaticDb.Statuses);
        }
    }
}
namespace Avenga.TodoApp.DataAccess.Data
{
    public static class StaticDb
    {
        public static List<Todo> Todos { get; set; }
        public static List<Category> Categories { get; set; }
        public static List<Status> Statuses { get; set; }

        static StaticDb()
        {
            LoadCategories();
            LoadStatuses();
            LoadTodos();
        }
        private static void LoadCategories()
        {
            Categories = new List<Category>
            {
                new Category { Id = 1, Name = "Work" },
                new Category { Id = 2, Name = "Home" },
                new Category { Id = 3, Name = "Exercise" },
                new Category { Id = 4, Name = "Shopping" },
                new Category { Id = 5, Name = "Hobbie" },
                new Category { Id = 6, Name = "FreeTime" }
            };
        }
        private static void LoadStatuses()
        {
            Statuses = new List<Status>
            {
                new Status { Id = 1, Name = "Open" },
                new Status { Id = 2, Name = "Closed" }
            };
        }
        private static void LoadTodos()
        {
            Todos = new List<Todo>
            {
                new Todo
                {
                    Id = 1,
                    Description = "Finish project presentation",
                    DueDate = DateTime.Today.AddDays(2),
                    CategoryId = 1, // Work
                    StatusId = 1    // Open
                },
                new Todo
                {
                    Id = 2,
                    Description = "Clean the kitchen",
                    DueDate = DateTime.Today.AddDays(-1),
                    CategoryId = 2, // Home
                    StatusId = 1    // Open
                },
                new Todo
                {
                    Id = 3,
                    Description = "Morning jog in the park",
                    DueDate = DateTime.Today,
                    CategoryId = 3, // Exercise
                    StatusId = 2    // Closed
                },
                new Todo
                {
                    Id = 4,
                    Description = "Buy groceries for the week",
                    DueDate = DateTime.Today.AddDays(3),
                    CategoryId = 4, // Shopping
                    StatusId = 1    // Open
                },
                new Todo
                {
                    Id = 5,
                    Description = "Read a chapter from a novel",
                    DueDate = DateTime.Today.AddDays(4),
                    CategoryId = 6, // FreeTime
                    StatusId = 1    // Open
                }
            };
        }
    }
}
namespace Avenga.TodoApp.DataAccess.Repositories
{
    public interface IRepository<T> where T : BaseEntity
    {
        IEnumerable<T> GetAll();
        T GetById(int id);
        void Create(T entity);
        void Update(T entity);
        void Delete(int id);
    }
}
namespace Avenga.TodoApp.DataAccess.Repositories
{
    public class CategoryRepository : IRepository<Category>
    {
        public IEnumerable<Category> GetAll()
        {
            return StaticDb.Categories;
        }
        public Category GetById(int id)
        {
            throw new NotImplementedException();
        }
        public void Create(Category entity)
        {
            throw new NotImplementedException();
        }
        public void Update(Category entity)
        {
            throw new NotImplementedException();
        }
        public void Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
namespace Avenga.TodoApp.DataAccess.Repositories
{
    public class TodoRepository : IRepository<Todo>
    {
        //public IEnumerable<Todo> GetAll() => StaticDb.Todos;

        public IEnumerable<Todo> GetAll()
        {
            return StaticDb.Todos;
        }
        public Todo GetById(int id)
        {
            return StaticDb.Todos.SingleOrDefault(x => x.Id == id);
        }
        public void Create(Todo entity)
        {
            entity.Id = StaticDb.Todos.Count + 1;
            StaticDb.Todos.Add(entity);
        }
        public void Update(Todo entity)
        {
            Todo todoFromDb = StaticDb.Todos.SingleOrDefault(x => x.Id == entity.Id);
            int index = StaticDb.Todos.IndexOf(todoFromDb);
            StaticDb.Todos[index] = entity;
        }
        public void Delete(int id)
        {
            Todo todoFromDb = StaticDb.Todos.SingleOrDefault(x => x.Id == id);
            StaticDb.Todos.Remove(todoFromDb);
        }
    }
}
namespace Avenga.TodoApp.Services.Dtos
{
    public class TodoDto
    {
        public int Id { get; set; }

        [Display(Name = "Todo Description")]
        public string Description { get; set; }

        [Display(Name = "Done until")]
        public DateTime DueDate { get; set; }

        [Display(Name = "Todo category")]
        public string Category { get; set; }

        [DisplayName("Todo status")]
        public string Status { get; set; }

        public int StatusId { get; set; }
    }
}
namespace Avenga.TodoApp.ViewModels
{
    public class CategoryVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
namespace Avenga.TodoApp.ViewModels
{
    public class CreateTodoVM
    {
        [Required(ErrorMessage = "Please insert descrpition")]
        //[MaxLength(10, ErrorMessage = "Description can have only 10 characters.")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Please insert due date")]
        public DateTime DueDate { get; set; }
        public List<CategoryVM> Categories { get; set; } = new List<CategoryVM>();

        [Required(ErrorMessage = "Please select Category")]
        public int CategoryId { get; set; }
        public int StatusId { get; set; }
    }
}
namespace Avenga.TodoApp.Services.Services.Interfaces
{
    public interface ICategoryService
    {
        List<CategoryVM> GetAllCategories();
    }
}
namespace Avenga.TodoApp.Services.Services.Interfaces
{
    public interface ITodoService
    {
        IEnumerable<TodoDto> GetAllTodos();
        void AddTodo(CreateTodoVM createTodoVM);
        bool MarkComplete(int todoId);
        void RemoveComplete();
    }
}
namespace Avenga.TodoApp.Services.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly IRepository<Category> _categoryRepository;

        public CategoryService(IRepository<Category> categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public List<CategoryVM> GetAllCategories()
        {
            List<CategoryVM> categories = new List<CategoryVM>();
            var categoriesFromDb = _categoryRepository.GetAll();
            foreach (var category in categoriesFromDb)
            {
                categories.Add(new CategoryVM
                {
                    Id = category.Id,
                    Name = category.Name,
                });
            }
            return categories;
        }
    }
}
namespace Avenga.TodoApp.Services.Services
{
    public class TodoService : ITodoService
    {
        private readonly IRepository<Todo> _todoRepository;
        public TodoService(IRepository<Todo> todoRepository)
        {
            _todoRepository = todoRepository;
        }

        public void AddTodo(CreateTodoVM createTodoVM)
        {
            var newTodo = new Todo
            {
                Description = createTodoVM.Description,
                DueDate = createTodoVM.DueDate,
                CategoryId = createTodoVM.CategoryId,
                StatusId = 1
            };

            _todoRepository.Create(newTodo);
        }

        public IEnumerable<TodoDto> GetAllTodos()
        {
            var todosDto = new List<TodoDto>();
            IEnumerable<Todo> todos = _todoRepository.GetAll();
            if (todos != null && todos.ToList().Count > 0)
            {
                // Map from Todo to TodoDto
                foreach (var todo in todos)
                {
                    todosDto.Add(new TodoDto
                    {
                        Id = todo.Id,
                        Description = todo.Description,
                        DueDate = todo.DueDate,
                        Category = StaticDb.Categories.SingleOrDefault(x => x.Id == todo.CategoryId).Name,
                        Status = StaticDb.Statuses.SingleOrDefault(x => x.Id == todo.StatusId).Name,
                        StatusId = todo.StatusId
                    });
                }
                return todosDto;
            }
            return todosDto;
        }

        public bool MarkComplete(int todoId)
        {
            var todo = _todoRepository.GetById(todoId);
            if (todo is null)
            {
                return false;
            }
            todo.StatusId = 2;
            _todoRepository.Update(todo);
            return true;
        }

        public void RemoveComplete()
        {
            var completedTodos = _todoRepository.GetAll()
                .Where(x => x.StatusId == 2).ToList();

            foreach (var todo in completedTodos)
            {
                _todoRepository.Delete(todo.Id);
            }
        }
    }
}
namespace Avenga.TodoApp.Web.Controllers
{
    public class TodoController : Controller
    {
        private readonly ITodoService _todoService;
        private readonly ICategoryService _categoryService;
        public TodoController(ITodoService todoService, ICategoryService categoryService)
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
            CreateTodoVM createTodoVM = new CreateTodoVM();
            createTodoVM.DueDate = DateTime.Now;
            createTodoVM.Categories = _categoryService.GetAllCategories();
            return View(createTodoVM);
        }

        [HttpPost]
        public IActionResult Create(CreateTodoVM model)
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
            if (!response)
            {
                //TempData["ErrorMessage"] = "Todo does not exists!";
                ViewBag.ErrorMessage = "Todo does not exists!";
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
------
@model CreateTodoVM

<div class="container">
    <div class="row">
        <h2>Add todo</h2>
        <div class="col-md-6">
            <form asp-action="Create" asp-controller="Todo" method="post">
            <div asp-validation-summary="All" class="text-danger"></div>
                <div>
                    <label asp-for="Description" class="form-label"></label>
                    <input asp-for="Description" class="form-control"/>
                </div>
                <div>
                    <label asp-for="DueDate" class="form-label"></label>
                    <input asp-for="DueDate" class="form-control" />
                </div>
                <div>
                    <label asp-for="CategoryId" class="form-label"></label>
                    <select class="form-select" 
                            asp-for="CategoryId"
                            asp-items="@(new SelectList(Model.Categories, "Id", "Name"))">
                        <option value="0">Select category</option>
                    </select>
                </div>

                <button type="submit" class="btn btn-primary mt-4">Create</button>
            </form>
        </div>
    </div>
</div>
--------
@model List<TodoDto>

<div class="container">
    <div class="row">
        <h2>My Todo list:</h2>
        <div class="col-md-12">
            @if (ViewBag.ErrorMessage is not null)
            {
                <h6 class="alert alert-danger">@ViewBag.ErrorMessage</h6>
            }
            <table class="table table-bordered table-striped mt-2">
                <thead>
                    <tr>
                        <th>
                            <label asp-for="@Model.FirstOrDefault().Description"></label>
                        </th>
                        <th>
                            <label asp-for="@Model.FirstOrDefault().DueDate"></label>
                        </th>
                        <th>
                            <label asp-for="@Model.FirstOrDefault().Category"></label>
                        </th>
                        <th>
                            <label asp-for="@Model.FirstOrDefault().Status"></label>
                        </th>
                        <th class="w-25"></th>
                    </tr>
                </thead>
                <tbody>
                    <form asp-action="MarkComplete" asp-controller="Todo" method="post">
                        @foreach (var todo in Model)
                        {
                            string overdueClass = todo.DueDate.Date < DateTime.Now.Date ? "bg-danger" : "";

                        <tr>
                            <td>@todo.Description</td>
                            <td class="@overdueClass">@todo.DueDate.ToShortDateString()</td>
                            <td>@todo.Category</td>
                            <td>@todo.Status</td>
                            <td>
                                    @if(todo.StatusId == 1)
                                    {
                                        <button type="submit" class="btn btn-outline-primary btn-sm" name="@nameof(TodoDto.Id)" value="@todo.Id">Mark as complete</button>
                                    }
                            </td>
                        </tr>
                    }
                    </form>
                </tbody>
            </table>
            <div class="row">
                <form asp-action="RemoveComplete" asp-controller="Todo" method="post">
                    <a asp-action="Create" class="btn btn-primary">Add new todo</a>
                    <button type="submit" class="btn btn-outline-danger">Remove all completed</button>
                </form>
            </div>
        </div>
    </div>
</div>
-------
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();


builder.Services.AddDbContext<TodoDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("TodoDbConnString"));
});


//builder.Services.AddScoped<IRepository<Todo>, TodoRepository>();
builder.Services.AddScoped<IRepository<Todo>, TodoEfRepository>();
//builder.Services.AddScoped<IRepository<Category>, CategoryRepository>();
builder.Services.AddScoped<IRepository<Category>, CategoryEfRepository>();

builder.Services.AddScoped<ITodoService, TodoService>();
builder.Services.AddScoped<ICategoryService, CategoryService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
