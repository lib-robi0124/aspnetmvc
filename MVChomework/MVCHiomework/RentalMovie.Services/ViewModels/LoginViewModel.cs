using System.ComponentModel.DataAnnotations;

namespace RentalMovie.Services.ViewModels
{
    public class LoginViewModel
    {
        [Required]
        public string CardNumber { get; set; } = null!;
    }
}
