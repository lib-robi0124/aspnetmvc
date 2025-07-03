namespace TodoApp.Web.Models
{
    public class CreateTodoVm
    {
        public string Description { get; set; }
        public DateTime DueDate { get; set; }
        public List<CategoryVM> Categories { get; set; } = new List<CategoryVM>();
        public int CategoryId { get; set; }
        public int StatusID { get; set; }

    }
}
