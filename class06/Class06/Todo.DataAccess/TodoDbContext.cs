using Microsoft.EntityFrameworkCore;
using TodoApp.DataAccess.Data;
using TodoApp.Domain;

namespace TodoApp.DataAccess
{
    public class TodoDbContext : DbContext
    {
        public TodoDbContext(DbContextOptions options) : base(options)
        {  }
        public DbSet<Todo> Todos { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Status> Statutes { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Todo>().HasData(StaticDb.Todos);
            modelBuilder.Entity<Category>().HasData(StaticDb.Categories);
            modelBuilder.Entity<Status>().HasData(StaticDb.Statuses);


        }
    }
}
