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
            var todoDto = new List<TodoDto>();
            var todos = _todoRepository.GetAll();
            if (todos !== null && todos.ToList().Count > 0)
            {
                //map from todo to todoDto
                foreach (var to in todos)
                {

                }
                return todoDto;
            }
            return todoDto;
        }
    }
}
