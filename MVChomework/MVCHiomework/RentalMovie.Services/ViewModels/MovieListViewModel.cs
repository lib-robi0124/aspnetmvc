using RentalMovie.Services.Dtos;

namespace RentalMovie.Services.ViewModels
{
    public class MovieListViewModel
    {
        public int UserId { get; set; }
        public List<MovieDto> Movies { get; set; } = new();
    }
}
