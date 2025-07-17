namespace MovieRentalApp.Dtos
{
    public class RentalDto
    {
        public string MovieTitle { get; set; }
        public DateTime RentedOn { get; set; }
        public DateTime? ReturnedOn { get; set; }
    }
}
