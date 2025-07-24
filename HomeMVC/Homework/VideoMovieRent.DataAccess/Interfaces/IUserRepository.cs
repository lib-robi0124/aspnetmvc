using VideoMovieRent.Domain;

namespace VideoMovieRent.DataAccess.Interfaces
{
    public interface IUserRepository
    {
        User GetUserByCardNumber(string cardNumber);
        void Login(string cardNumber);
    }
}
