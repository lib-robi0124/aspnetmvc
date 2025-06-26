using TodoApp.DataAccess.Repositories;
using TodoApp.Domain;
using TodoApp.Services.Dtos;
using TodoApp.Services.Services.Interfaces;

namespace TodoApp.Services.Services
{
    public class TodoService : ITodoService
    {
        private readonly IRepository<Todo> _todoRepository;
        public TodoService(IRepository<Todo> todoRepository)
        {
            _todoRepository = todoRepository;
        }
        public IEnumerable<TodoDto> GetAllTodos()
        {
            var todosDto = new List<TodoDto>();
            var todos = _todoRepository.GetAll();
            if (todos != null && todos.ToList().Count > 0)
            {
                // Map from Todo to TodoDto
                foreach (var todo in todos)
                {
                    // TODO: Finish the mapping
                    //todosDto.Add(new TodoDto
                    //{
                    //    todo.Id = 
                    //})
                }
                return todosDto;
            }
            return todosDto;
        }
    }
}
