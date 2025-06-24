using TodoApp.Services.Dtos;

namespace TodoApp.Services.Services.Interfaces
{
    public interface ITodoService
    {
        IEnumerable<TodoDto> GetAllTodos();
    }
}
