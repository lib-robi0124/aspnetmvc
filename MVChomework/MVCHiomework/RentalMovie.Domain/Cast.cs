using RentalMovie.Domain.Enums;

namespace RentalMovie.Domain
{
    public class Cast : BaseEntity
    {
        public int MovieId { get; set; }
        public string Name { get; set; } = null!;
        public Part Part { get; set; } 
        public override string Print()
        {
            return $"Cast: {Name}, Part: {Part}, Movie ID: {MovieId}";
        }
    }
}
