using System.ComponentModel.DataAnnotations;

namespace VideoMovieRent.Services.Dtos
{
    public class RegisterDto
    {
        [Required] public string FullName { get; set; }
        [Required] public string CardNumber { get; set; }
        [Required] public int Age { get; set; }
    }
}
