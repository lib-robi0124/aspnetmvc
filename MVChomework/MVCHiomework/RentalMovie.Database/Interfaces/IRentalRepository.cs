using RentalMovie.Domain;

namespace RentalMovie.Database.Interfaces
{
    public interface IRentalRepository : IRepository<Rental>
    {
        IEnumerable<Rental> GetRentalsByUserId(int userId);
        IEnumerable<Rental> GetActiveRentals();
        IEnumerable<Rental> GetOverdueRentals();
        void MarkAsReturned(int rentalId);
        void ExtendRental(int rentalId, DateTime newReturnDate);
    }
}
