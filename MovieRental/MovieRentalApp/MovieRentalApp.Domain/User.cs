using MovieRentalApp.Domain.Enums;

namespace MovieRentalApp.Domain
{
    public class User : BaseEntity
    {
        public User() { }
        public string FullName { get; set; }
        public int Age { get; set; }
        public string CardNumber { get; set; }
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
