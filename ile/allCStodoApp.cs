namespace TodoApplication.Domain {
	public abstract class BaseEntity 
	{
		public int Id { get; set; }
	}
}
namespace TodoApplication.Domain
{
    public class Todo : BaseEntity
    {
        public string Description { get; set; }
        public DateTime DueDate { get; set; }
		public int StatusId { get; set; }
        public Status Status { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
      
    }
}
namespace TodoApplication.Domain 
{
	public class Category : BaseEntity
	{
		public string Name { get; set; }
	}
}
namespace TodoApplication.Domain
{
    public class Status : BaseEntity
    {
        public string Name { get; set; }
    }
}
namespace TodoApplication.DataAccess
{
    public class TodoAppDbContext : DbContext
    {
		public TodoAppDbContext(DbContextOptions<TodoAppDbContext> options) : base(options) { }
        public DbSet<Todo> Todo { get; set; }
        public DbSet<Status> Status { get; set; }
        public DbSet<Category> Category { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
			base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Todo>()
                .HasOne(todo => todo.Status)
                .WithMany()
                .HasForeignKey(todo => todo.StatusId);
        
            modelBuilder.Entity<Todo>()
                .HasOne(todo => todo.Category)
                .WithMany()
                .HasForeignKey(todo => todo.CategoryId);
               
        }
    }
}
namespace TodoApplication.DataAccess {
	public static class InMemoryDataBase {
		public static List<Category> Categories { get; set; }
		public static List<Status> Statuses { get; set; }
		public static List<Todo> Todos { get; set; }

		static InMemoryDataBase() 
		{
			LoadCategories();
			LoadStatuses();
			LoadTodos();
		}

		private static void LoadCategories() {
			Categories = new List<Category>()
			{
				new Category {Id = 1, Name = "Work" },
				new Category {Id = 2, Name = "Home" },
				new Category {Id = 3, Name = "Exercise" },
				new Category {Id = 4, Name = "Hobby" },
				new Category {Id = 5, Name = "Shopping" },
				new Category {Id = 6, Name = "Freetime" },
				new Category {Id = 7, Name = "Homework" }
			};
		}

		private static void LoadStatuses() 
		{
			Statuses = new List<Status>()
			{
				new Status { Id = 1, Name = "In Progress"},
				new Status {Id = 2, Name = "Completed" }
			};
		}

		private static void LoadTodos() 
		{
			Todos = new List<Todo>()
			{
				new Todo() { Id = 1, Description = "Test todo", DueDate = DateTime.Now.AddDays(3), CategoryId = 1, StatusId = 1},
				new Todo() { Id = 2, Description = "Homework PizzaApp", DueDate = DateTime.Now.AddDays(-5), CategoryId = 7, StatusId = 2},
			};
		}
	}
}
namespace TodoApplication.DataAccess.Interfaces 
{
	public interface IRepository <T> where T : BaseEntity 
	{
		IEnumerable<T> GetAll();
		T GetById(int id);
		void Add(T entity);
		void Update(T entity);
		void Delete(int id);
	}
}
namespace TodoApplication.DataAccess.Implementations 
{
	public class CategoryRepository : IRepository<Category>
	{
		public void Add(Category entity) 
		{
			entity.Id = InMemoryDataBase.Categories.Count + 1;
			InMemoryDataBase.Categories.Add(entity);
		}
		public void Delete(int id) 
		{
			var category = GetById(id);
			if (category is not null) 
			{
				InMemoryDataBase.Categories.Remove(category);
			}
		}
		public IEnumerable<Category> GetAll() 
		{
			return InMemoryDataBase.Categories;
		}
		public Category GetById(int id) 
		{
			return InMemoryDataBase.Categories.FirstOrDefault(c => c.Id == id);
		}
		public void Update(Category entity) 
		{
			var category = GetById(entity.Id);
			if (category is not null) {
				var categoryIndex = InMemoryDataBase.Categories.IndexOf(category);
				InMemoryDataBase.Categories[categoryIndex] = entity;
			}
		}
	}
}
namespace TodoApplication.DataAccess.Interfaces 
{
	public interface ITodoRepository : IRepository<Todo>
	{
		IEnumerable<Todo> GetCompletedTodos();
	}
}
namespace TodoApplication.DataAccess.Interfaces 
{
	public interface ITodoRepository : IRepository<Todo>
	{
		IEnumerable<Todo> GetCompletedTodos();
	}
}
namespace TodoApplication.DataAccess.Implementations 
{
	public class StatusRepository : IRepository<Status> 
	{
		public void Add(Status entity)
		{
			entity.Id = InMemoryDataBase.Statuses.Count + 1;
			InMemoryDataBase.Statuses.Add(entity);
		}

		public void Delete(int id) 
		{
			var status = GetById(id);
			if (status is not null) {
				InMemoryDataBase.Statuses.Remove(status);
			}
		}
		public IEnumerable<Status> GetAll() 
		{
			return InMemoryDataBase.Statuses;
		}

		public Status GetById(int id) 
		{
			return InMemoryDataBase.Statuses.FirstOrDefault(s => s.Id == id);
		}

		public void Update(Status entity) 
		{
			var status = GetById(entity.Id);
			if (status is not null) {
				var statusIndex = InMemoryDataBase.Statuses.IndexOf(status);
				InMemoryDataBase.Statuses[statusIndex] = entity;
			}
		}
	}
}
namespace TodoApplication.Dtos.Dto 
{
	public class CategoryDto 
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public bool IsSelected { get; set; }
	}
}
namespace TodoApplication.Dtos.Dto 
{
	public class FilterDto 
	{
		public List<CategoryDto> Categories {  get; set; }
		public List<StatusDto>Statuses { get; set; }
		public int CategoryId { get; set; } = 0;
		public int StatusId { get; set; } = 0;
	}
}
namespace TodoApplication.Dtos.Dto {
	public class TodoDto 
	{
		public int Id { get; set; }
		public string Description { get; set; }
		public DateTime DueDate { get; set; }
		public string Category { get; set; }
		public string Status { get; set; }
		public int StatusId { get; set; }

	}
}
namespace TodoApplication.Dtos.ViewModel 
{
	public class CreateTodoVM 
	{
		public string Description { get; set; }
		public DateTime DueDate { get; set; }
		public int CategoryId { get; set; }
		public int StatusId { get; set; }
	}
}
namespace TodoApplication.Dtos.ViewModel 
{
	public class FilterVM 
	{
		public int CategoryId { get; set; }

		public int StatusId { get; set; }
	}
}
namespace TodoApplication.Mapper 
{
	public static class MapperExtensions 
	{
		public static CategoryDto Map(this Category category) {
			return new CategoryDto { Id = category.Id, Name = category.Name };
		}

		public static StatusDto Map(this Status status) {
			return new StatusDto { Id = status.Id, Name = status.Name };
		}
	}
}
namespace TodoApplication.Services.Interfaces 
{
	public interface IFilterService 
	{
		List<CategoryDto> GetCategories();
		List<StatusDto>GetStatuses();
	}
}
namespace TodoApplication.Services.Interfaces 
{
	public interface IToDoService 
	{
		List<TodoDto> GetTodos(int? categoryId, int? statusId);
		bool MarkComplete(int todoId);
		void RemoveComplete();
		void AddTodo(CreateTodoVM createTodo);
	}
}
namespace TodoApplication.Services {
	public class FilterService : IFilterService {

		private readonly IRepository<Category> _categoryRepository;
		private readonly IRepository<Status> _statusRepository;

		public FilterService() {
			_categoryRepository = new CategoryRepository();
			_statusRepository = new StatusRepository();
		}
		public List<CategoryDto> GetCategories() {
			return _categoryRepository.GetAll().Select(c => c.Map()).ToList();
		}

		public List<StatusDto> GetStatuses() {
			return _statusRepository.GetAll().Select(s => s.Map()).ToList();
		}
	}
}
namespace TodoApplication.Services 
{
	public class TodoService : IToDoService 
	{
		private readonly ITodoRepository _todoRepository;
		private readonly IRepository<Category> _categoryRepository;
		private readonly IRepository<Status> _statusReposity;

		public TodoService() 
		{
			_todoRepository = new TodoRepository();
			_categoryRepository = new CategoryRepository();
			_statusReposity = new StatusRepository();
		}

		public List<TodoDto> GetTodos(int? categoryId, int? statusId) 
		{
			var todos = _todoRepository.GetAll();

			if(categoryId.HasValue && categoryId.Value > 0) 
			{
				todos = todos.Where(t => t.CategoryId == categoryId.Value).ToList();
			}

			if(statusId.HasValue && statusId > 0) 
			{
				todos = todos.Where(t => t.StatusId == statusId.Value).ToList();
			}

			var result = new List<TodoDto>();
			
			foreach (var todo in todos) 
			{
				result.Add(new TodoDto {
					Id = todo.Id,
					Description = todo.Description,
					DueDate = todo.DueDate,
					Category = _categoryRepository.GetById(todo.CategoryId).Name ?? string.Empty,
					Status = _statusReposity.GetById(todo.StatusId).Name ?? string.Empty,
					StatusId = todo.StatusId,
				});
			}
			return result;
		}

		public void AddTodo(CreateTodoVM createTodo) 
		{
			var newTodo = new Todo {
				Description = createTodo.Description,
				CategoryId = createTodo.CategoryId,
				DueDate = createTodo.DueDate,
				StatusId = 1
			};
			_todoRepository.Add(newTodo);
		}

		public bool MarkComplete(int todoId) 
		{
			var todo = _todoRepository.GetById(todoId);

			if (todo == null) return false;

			todo.StatusId = 2;
			_todoRepository.Update(todo);

			return true;
		}

		public void RemoveComplete() 
		{
			var completeTodos = _todoRepository.GetCompletedTodos();
			foreach (var todo in completeTodos) 
			{
				_todoRepository.Delete(todo.Id);
			}
		}
	}
}
namespace TodoApplication.Controllers 
{
	[Route("")]
	public class TodoController : Controller 
	{
		private readonly TodoService _todoService;
		private readonly FilterService _filterService;

		public TodoController() 
		{
			_todoService = new TodoService();
			_filterService = new FilterService();
		}
		public IActionResult Index() 
		{
			int? categoryId = null;
			int? statusId = null;

			ViewBag.Filter = new FilterDto();

			if (TempData["HasFilter"] != null) 
			{
				ViewBag.Filter.CategoryId = (int)TempData["Category"];
				categoryId = (int)TempData["Category"];
				ViewBag.Filter.StatusId = (int)TempData["Status"];
				statusId = (int)TempData["Status"];
			}

			ViewBag.Filter.Categories = _filterService.GetCategories();
			ViewBag.Filter.Statuses = _filterService.GetStatuses();

			var todos = _todoService.GetTodos(categoryId, statusId);
			return View(todos);
		}

		[HttpGet("mark-complete")]
		public IActionResult MarkComplete(int id) 
		{
			var todoMarkComplete = _todoService.MarkComplete(id);
			if (!todoMarkComplete) {
				TempData["ErrorMessage"] = "Todo does note exists";
			}
			return RedirectToAction("Index");
		}

		[HttpGet("remove-complete")]
		public IActionResult RemoveComplete() 
		{
			_todoService.RemoveComplete();
			return RedirectToAction("Index");
		}

		[HttpGet("add")]
		public IActionResult AddTodo() {
			ViewBag.Categories = _filterService.GetCategories();
			return View("AddTodo");
		}

		[HttpPost("add")]
		public IActionResult AddTodo(CreateTodoVM createTodoVM) 
		{
			if (createTodoVM.CategoryId == 0) 
			{
				ViewBag.Error = "Please select valid category";
				ViewBag.Categories = _filterService.GetCategories();
				return View(createTodoVM);
			}

			_todoService.AddTodo(createTodoVM);
			return RedirectToAction("Index");
		}

		[HttpPost("filter")]
		public IActionResult Filter(FilterVM filterVM) 
		{
			TempData["HasFilter"] = true;
			TempData["Category"] = filterVM.CategoryId;
			TempData["Status"] = filterVM.StatusId;

			return RedirectToAction("Index");
		}
	}
}
-----
@model FilterDto

<form asp-controller="Todo" asp-action="Filter" method="post">
	<div class="row">
		<div class="col-md-4">
			<div class="mb-3">
				<div class="form-label">Category</div>
				<select name="categoryId" class="form-select" asp-items="@(new SelectList(Model.Categories, "Id", "Name", Model.CategoryId))">
					<option value="0">All</option>
				</select>
			</div>
		</div>

		<div class="col-md-4">
			<div class="mb-3">
				<div class="form-label">Status</div>
				<select name="statusId" class="form-select" asp-items="@(new SelectList(Model.Statuses, "Id", "Name", Model.StatusId))">
					<option value="0">All</option>
				</select>
			</div>
		</div>
		<div class="col-md-3 p-4">
			<button type="submit" class="btn btn-outline-primary">Filter</button>
			<a asp-action="Index" class="btn btn-outline-info">Clear</a>
		</div>
	</div>
</form>
----------
@using TodoApplication.Dtos.ViewModel
@model CreateTodoVM

@if(ViewBag.Error != null)
{
	<h5 class="alert alert-warning">@ViewBag.Error</h5>
}

<form asp-controller="Todo" asp-action="AddTodo" method="post">
	<div class="md-3">
		<label asp-for="Description" class="form-label">Description</label>
		<input asp-for="Description" class="form-control"/>
	</div>
	<div class="md-3">
		<label asp-for="CategoryId" class="form-label">Category</label>
		<select asp-for="CategoryId" class="form-select" asp-items="@(new SelectList(ViewBag.Categories, "Id", "Name"))">
			<option value="0">None</option>
		</select>
	</div>
	<div class="md-3">
		<label asp-for="DueDate" class="form-label">Due Date</label>
		<input asp-for="DueDate" class="form-control"/>
	</div>
	<button type="submit" class="btn btn-outline-primary">Create</button>
</form>
------
@model IEnumerable<TodoDto>

@if(TempData.TryGetValue("ErrorMessgae", out var errorMessage))
{
	<h4 class="text-danger alert alert-danger mt-2 mb-3">@errorMessage</h4>
}

<div class="row">
	<div class="col-md-12">
		@Html.Partial("~/Views/Todo/Partial/_FilterPartial.cshtml", (FilterDto)ViewBag.Filter)
	</div>
</div>

	<div class="row">
		<div class="col-md-12">
			<table class="table table-bordered table-striped mt-2">
				<thead>
					<tr>
						<th>Description</th>
						<th>DueDate</th>
						<th>Category Name</th>
						<th>Status Name</th>
						<th class="w-25">Actions</th>

					</tr>
				</thead>
				<tbody>
					@foreach(TodoDto todo in Model)
					{
					string dueDate = todo.DueDate < DateTime.Now ? "bg-danger" : "";
					<tr>
						<td>@todo.Description</td>
						<td class="@dueDate">@todo.DueDate</td>
						<td>@todo.Category</td>
						<td>@todo.Status</td>
						<td>
							@if(todo.Status == "Completed")
							{
								<button disabled type="submit" class="btn btn-outline-primary btn-sm">Mark Complete</button>
							}
							else
							{
								<a asp-action="MarkComplete" class="btn btn-outline-primary btn-sm"
								name="@nameof(TodoDto.Id)" asp-route-id="@todo.Id">Mark Complete</a>
							}
							
						</td>
					</tr>
					}
				</tbody>
			</table>
			<div>
				<a asp-action="AddTodo" class="btn btn-outline-primary">Create Todo</a>
			</div>
			<div>
				<a asp-action="RemoveComplete" class="btn btn-outline-danger">Remove Complete</a>
			</div>
		</div>
	</div>
-------
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

#region Register Database
// Example 01 (hardcoded conn string)
string connectionString = "Server=.\\SQLEXPRESS;Database=TodoApplicationDb;Trusted_Connection=True;Integrated Security=true;Encrypt=False;";

builder.Services.AddDbContext<TodoAppDbContext>(options => options.UseSqlServer(connectionString));
#endregion

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
