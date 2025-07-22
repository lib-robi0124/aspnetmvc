using RentalMovie.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace RentalMovie.Domain
{
    public class User : BaseEntity
    {
        public string FullName { get; set; } = null!;
        public int Age { get; set; }
        [Required]
        public string CardNumber { get; set; } = null!;
        public DateTime CreatedOn { get; set; }
        public bool IsSubscriptionExpired { get; set; }
        public SubscriptionType SubscriptionType { get; set; }
        public override string Print()
        {
            return $"User: {FullName}, Age: {Age}, Card Number: {CardNumber}, " +
                $"Created On: {CreatedOn.ToShortDateString()}, " +
                $"Subscription Type: {SubscriptionType}, Subscription Expired: {IsSubscriptionExpired}";
        }
    }
}
