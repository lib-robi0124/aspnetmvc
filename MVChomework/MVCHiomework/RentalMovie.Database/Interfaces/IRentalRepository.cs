using RentalMovie.Domain;

namespace RentalMovie.Database.Interfaces
{
    public interface IRentalRepository
    {
        IEnumerable<Rental> GetRentalsByUserId(int userId);
        public bool MarkAsReturned(int rentalId, int userId);
        bool RentMovie(int movieId, int userId);
    }
}
