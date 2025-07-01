using TodoApp.DataAccess.Data;
using TodoApp.DataAccess.Repositories;
using TodoApp.Domain;
using TodoApp.Services.Dtos;
using TodoApp.Services.Services.Interfaces;
using TodoApp.Web.Models;

namespace TodoApp.Services.Services
{
    public class TodoService : ITodoService
    {
        private readonly IRepository<Todo> _todoRepository;
        public TodoService(IRepository<Todo> todoRepository)
        {
            _todoRepository = todoRepository;
        }

        public void AddTodo(CreateTodoVm createTodoVM)
        {
            var newTodo = new Todo
            {
                Id = StaticDb.Todos.Count + 1,
                Description = createTodoVM.Description,
                DueDate = createTodoVM.DueDate,
                CategoryId = createTodoVM.Category,


            }

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
    }
}
