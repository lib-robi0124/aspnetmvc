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

        
        public bool MarkComplete(int id)
        {
            var todo = _todoRepository.GetById(id);
            if (todo is null)
            {
                return false;
            }
            todo.StatusId = 2;
            var index = _todoRepository.GetAll().ToList().IndexOf(todo);
            _todoRepository.GetAll().ToList()[index] = todo;
            return true;
        }

      

        public void RemoveComplete()
        {
            var completeTodos = _todoRepository.GetAll().Where(x => x.StatusId == 2).ToList();
            foreach (var todo in completeTodos)
            {
                _todoRepository.Delete(todo.Id);
            }
        }
    }
}
