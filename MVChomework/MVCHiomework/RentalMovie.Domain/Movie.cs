using RentalMovie.Domain.Enums;

namespace RentalMovie.Domain
{
    public class Movie : BaseEntity
    {
        public string Title { get; set; } = null!; // Ensure Title is never null
        public Genre Genre { get; set; } // Consider using an Enum here
        public Language Language { get; set; } // Consider using an Enum here
        public bool IsAvailable { get; set; }
        public DateTime ReleaseDate { get; set; }
        public TimeSpan Length { get; set; }
        public int AgeRestriction { get; set; }
        public int Quantity { get; set; }
        public string? ImagePath { get; set; }
        public override string Print()
        {
            return $"Title: {Title}, Genre: {Genre}, Language: {Language}, " +
                   $"Available: {IsAvailable}, Release Date: {ReleaseDate.ToShortDateString()}, " +
                   $"Length: {Length} mins, Age Restriction: {AgeRestriction}, Quantity: {Quantity}";
        }
       
    }
}
