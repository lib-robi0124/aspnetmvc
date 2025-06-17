using model.DataBase;
using model.Models.DtoModels;
using model.Models.Entities;

namespace model.Services
{
    public class StudentService
    {
        public StudentWithCourseDto GetStudentWithCourse(int id)
        {
            Student student = InMemoryDb.Students.SingleOrDefault(x => x.Id == id);

            if (student == null)
            {
                return null;
            }

            StudentWithCourseDto studentWithCourse = new StudentWithCourseDto()
            {
                Id = student.Id,
                FullName = $"{student.FirstName} {student.LastName}",
                NameOfCourse = student.ActiveCourse.Name,
                Age = DateTime.Now.Year - student.DateOfBirth.Year
            };

            return studentWithCourse;
        }
        public List<ListAllStudentsDto> GetAllStudents()
        {
            return InMemoryDb.Students.Select(student =>
            new ListAllStudentsDto
            {
                FullName = $"{student.FirstName} {student.LastName}"
            }).ToList();
        }
    }
}
