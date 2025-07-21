namespace MovieRentalApp.Dtos
{
    public class FilterDto
    {
        public List<MovieDto> Movies { get; set; }
        public List<RentalDto> Rentals { get; set; }
        public int MovieId { get; set; }
        public int UserId { get; set; }

    }
}
