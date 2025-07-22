using RentalMovie.Database.Interfaces;
using RentalMovie.Domain;

namespace RentalMovie.Database.Implementation
{
    public class RentalRepository : IRentalRepository
    {
        public void Add(Rental entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public void ExtendRental(int rentalId, DateTime newReturnDate)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Rental> GetActiveRentals()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Rental> GetAll()
        {
            throw new NotImplementedException();
        }

        public Rental GetById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Rental> GetOverdueRentals()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Rental> GetRentalsByUserId(int userId)
        {
            throw new NotImplementedException();
        }

        public void MarkAsReturned(int rentalId)
        {
            throw new NotImplementedException();
        }

        public void Update(Rental entity)
        {
            throw new NotImplementedException();
        }
    }
}
