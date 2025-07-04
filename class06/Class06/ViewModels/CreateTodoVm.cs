using System.ComponentModel.DataAnnotations;

namespace TodoApp.Web.Models
{
    public class CreateTodoVm
    {
        [Required(ErrorMessage = "Please insert descrpition")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Please insert due date")]
        public DateTime DueDate { get; set; }
        public List<CategoryVM> Categories { get; set; } = new List<CategoryVM>();

        [Required(ErrorMessage = "Please select Category")]
        public int CategoryId { get; set; }
        public int StatusID { get; set; }

    }
}
