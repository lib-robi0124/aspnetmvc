using System.ComponentModel.DataAnnotations;

namespace VideoMovieRent.ViewModels
{
    public class RegisterViewModel
    {
        [Required] public string FullName { get; set; }
        [Required] public string CardNumber { get; set; }
        [Required] public int Age { get; set; }
    }

}
