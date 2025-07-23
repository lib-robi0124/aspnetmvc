using RentalMovie.Database.Interfaces;
using RentalMovie.Domain;
using RentalMovie.Services.Services.Interfaces;

namespace RentalMovie.Services.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public User GetUserByCardNumber(string cardNumber)
        {
            return _userRepository.GetUserByCardNumber(cardNumber);
        }
        public void Login(string cardNumber)
        {
            _userRepository.Login(cardNumber);
        }
    }
}
