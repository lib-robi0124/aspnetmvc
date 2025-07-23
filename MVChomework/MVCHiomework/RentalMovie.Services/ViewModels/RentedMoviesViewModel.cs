using RentalMovie.Domain;

namespace RentalMovie.Services.ViewModels
{
    public class RentedMoviesViewModel
    {
        public int UserId { get; set; }
        public List<Rental> RentedMovies { get; set; } = new();
    }
}
