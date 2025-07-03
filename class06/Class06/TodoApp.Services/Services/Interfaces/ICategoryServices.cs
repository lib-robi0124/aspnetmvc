using TodoApp.Web.Models;

namespace TodoApp.Services.Services.Interfaces
{
    public interface ICategoryServices
    {
        List<CategoryVM> GetAllCategories();
    }
}
