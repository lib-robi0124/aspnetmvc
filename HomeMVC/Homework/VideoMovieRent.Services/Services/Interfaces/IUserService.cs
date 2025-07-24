using VideoMovieRent.Domain;

namespace VideoMovieRent.Services.Interfaces
{
    public interface IUserService
    {
        User GetUserByCardNumber(string cardNumber);
    }
}
