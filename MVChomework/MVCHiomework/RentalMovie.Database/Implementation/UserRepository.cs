using RentalMovie.Database.Interfaces;
using RentalMovie.Domain;

namespace RentalMovie.Database.Implementation
{
    public class UserRepository : IUserRepository
    {
        private readonly RentalMovieDbContext _db;

        public UserRepository(RentalMovieDbContext db)
        {
            _db = db;
        }
        public User GetUserByCardNumber(string cardNumber)
        {
            return _db.Users.FirstOrDefault(x => x.CardNumber == cardNumber);
        }

        public void Login(string cardNumber)
        {
            var user = _db.Users.FirstOrDefault(x => x.CardNumber == cardNumber);
        }
    }
}
