using MovieRentalApp.Domain.Enums;

namespace MovieRentalApp.Domain
{
    public class Cast : BaseEntity
    {
        public string MovieId { get; set; }
        public string Name { get; set; }
        public Part Part { get; set; } 
        public override string Print()
        {
            return $"Cast: {Name}, Part: {Part}, Movie ID: {MovieId}";
        }
    }
}
