using TodoApp.DataAccess.Repositories;
using TodoApp.Domain;
using TodoApp.Services.Services.Interfaces;
using TodoApp.Web.Models;

namespace TodoApp.Services.Services
{
    public class CategoryServices : ICategoryServices
    {
        private readonly IRepository<Category> _categoryRepository;

        public CategoryServices(IRepository<Category> categoryRepository)
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
                    Name = category.Name
                });
            }
            return categories;
        }
    }
}
