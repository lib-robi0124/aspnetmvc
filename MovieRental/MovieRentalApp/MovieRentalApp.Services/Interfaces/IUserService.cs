using MovieRentalApp.Domain;

namespace MovieRentalApp.Services.Interfaces
{
    public interface IUserService
    {
        User Login(string cardNumber);
        User GetById(int id);
    }
}
