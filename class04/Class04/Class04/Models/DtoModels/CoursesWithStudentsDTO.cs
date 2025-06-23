namespace Class04.Models.DtoModels
{
    public class CoursesWithStudentsDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<StudentDTO> Students { get; set; }
        public CoursesWithStudentsDTO()
        {
           Students = new List<StudentDTO>();
        }
    }
}
