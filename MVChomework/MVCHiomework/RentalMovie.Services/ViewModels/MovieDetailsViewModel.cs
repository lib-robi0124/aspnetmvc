using RentalMovie.Services.Dtos;

namespace RentalMovie.Services.ViewModels
{
    public class MovieDetailsViewModel
    {
        public MovieDetailsDto Movie { get; set; }
        public int UserId { get; set; }
        public bool CanRent => Movie.Quantity > 0;
    }
}
