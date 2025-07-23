using RentalMovie.Domain;

namespace RentalMovie.Services.Services.Interfaces
{
    public interface IUserService
    {
        User GetUserByCardNumber(string cardNumber);
    }
}
