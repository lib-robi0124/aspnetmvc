using TodoApp.Domain;

namespace TodoApp.DataAccess.Repositories
{
    public class TodoEfRepository : IRepository<Todo>
    {
        private readonly TodoDbContext  _db;
        public TodoEfRepository(TodoDbContext db)
        {
            _db = db;
        }

        public void Create(Todo entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Todo> GetAll()
        {
            return _db.Todos;
        }

        public Todo GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Todo entity)
        {
            _db.Todos.Update(entity);
            _db.SaveChanges();
        }
    }
}
