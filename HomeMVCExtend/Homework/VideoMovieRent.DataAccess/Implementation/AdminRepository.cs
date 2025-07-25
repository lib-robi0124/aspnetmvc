using VideoMovieRent.DataAccess.Interfaces;
using VideoMovieRent.Domain;

namespace VideoMovieRent.DataAccess.Implementation
{
    public class AdminRepository : IAdminRepository
    {
        private readonly VideoMovieRentDbContext _context;

        public AdminRepository(VideoMovieRentDbContext context)
        {
            _context = context;
        }

        public Admin? GetByUsernameAndPassword(string username, string password)
        {
            return _context.Admins.FirstOrDefault(a =>
                a.Username == username && a.Password == password);
        }
    }
}
