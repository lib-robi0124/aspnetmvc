using TodoApp.Domain;

namespace TodoApp.DataAccess.Repositories
{
    public class CategoryEfRepository : IRepository<Category>
    {
        private readonly TodoDbContext _db;

        public CategoryEfRepository(TodoDbContext db)
        {
            _db = db;
        }
        public void Create(Category entity)
        {
            _db.Categories.Add(entity);
            _db.SaveChanges();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Category> GetAll()
        {
            throw new NotImplementedException();
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
