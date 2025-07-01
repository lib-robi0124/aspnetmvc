using TodoApp.Services.Dtos;
using TodoApp.Web.Models;

namespace TodoApp.Services.Services.Interfaces
{
    public interface ITodoService
    {
        IEnumerable<TodoDto> GetAllTodos();
        void AddTodo(CreateTodoVm createTodoVM);
    }
}
