namespace TodoApp.Web.Models
{
    public class CreateTodoVm
    {
        public string Description { get; set; }
        public DateTime DueDate { get; set; }
        public List<CategoryVM> Categories { get; set; }
        public int CategoryID { get; set; }
        public int StatusID { get; set; }

    }
}
