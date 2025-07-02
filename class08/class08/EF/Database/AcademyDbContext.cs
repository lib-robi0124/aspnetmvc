using EF.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography.X509Certificates;

namespace EF.Database
{
    public class AcademyDbContext : DbContext
    {
        public AcademyDbContext(DbContextOptions<AcademyDbContext> options) : base(options)
        { }
        

            public DbSet<Student> Students { get; set; }
            public DbSet<Course> Courses { get; set; }
            protected override void OnModelCreating(ModelBuilder modelBuilder)
            {
                base.OnModelCreating(modelBuilder);

            List<Course> courses = new()
                {
                    new Course { Id = 1, Name = "Mathematics", NumberOfClasses = 10 },
                    new Course { Id = 2, Name = "Science", NumberOfClasses = 15 }
                };

            List<Student> students = new()
                {
                    new Student { Id = 1, FirstName = "John", LastName = "Doe", DateOfBirth = DateTime.Now.AddYears(-23), ActiveCourseId = 1 },
                    new Student { Id = 2, FirstName = "Jane", LastName = "Smith", DateOfBirth = DateTime.Now.AddYears(-24), ActiveCourseId = 2 },
                    new Student { Id = 3, FirstName = "Bob", LastName = "Bobsky", DateOfBirth = DateTime.Now.AddYears(-18), ActiveCourseId = 1 }

                };



                modelBuilder.Entity<Course>().HasData(courses);
                modelBuilder.Entity<Student>().HasData(students);

            //Fluent API configuration for relationships
            //modelBuilder.Entity<Student>()
            //    .HasOne(s => s.ActiveCourses)
            //    .WithMany(c => c.Students)
            //    .HasForeignKey(s => s.ActiveCourseId);

             }

    }
    
    
}
