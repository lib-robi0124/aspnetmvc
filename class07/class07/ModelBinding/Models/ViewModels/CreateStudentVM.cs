using System.ComponentModel.DataAnnotations;

namespace ModelBinding.Models.ViewModels
{
    public class CreateStudentVM
    {
        [Required(ErrorMessage ="Firstname is requered")]
        [MinLength(3, ErrorMessage ="Firstname min 3 characters")]
        [MaxLength(30, ErrorMessage ="max 30 characters")]
        [Display(Name = "Firstname")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Lastname is requered")]
        [MinLength(3, ErrorMessage = "Lastname min 3 characters")]
        [MaxLength(30, ErrorMessage = "max 30 characters")]
        [Display(Name = "Lastname")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Email is requered")]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        //[Required(ErrorMessage = "Additional is requered")]
        [MinLength(5, ErrorMessage = "Additional min 5 characters")]
        [MaxLength(50, ErrorMessage = "max 50 characters")]
        [Display(Name = "Additional Info")]
        public string AdditionalInfo { get; set; }

        [Required(ErrorMessage = "Date of birth is requered")]
        [Display(Name = "Date Of Birth")]
        public DateTime DateOfBirth { get; set; }
    }
}
