using RentalMovie.Domain;

namespace RentalMovie.Database.Interfaces
{
    public interface IUserRepository
    {
        User GetUserByCardNumber(string cardNumber);
        void Login(string cardNumber);
    }
}
