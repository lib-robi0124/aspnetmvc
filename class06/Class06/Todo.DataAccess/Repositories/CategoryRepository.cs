using TodoApp.DataAccess.Data;
using TodoApp.Domain;

namespace TodoApp.DataAccess.Repositories
{
    public class CategoryRepository : IRepository<Category>
    {
        public void Create(Category entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Category> GetAll()
        {
            return StaticDb.Categories;
        }

        public Category GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Category entity)
        {
            throw new NotImplementedException();
        }
    }
}
