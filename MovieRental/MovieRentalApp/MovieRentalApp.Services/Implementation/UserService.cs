using MovieRentalApp.Database;
using MovieRentalApp.Domain;
using MovieRentalApp.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace MovieRentalApp.Services.Implementation
{
    public class UserService : IUserService
    {
        //    private readonly AppDbContext _context;
        //    public UserService(AppDbContext context) => _context = context;

        //    public User Login(string cardNumber) =>
        //        _context.Users.FirstOrDefault(u => u.CardNumber == cardNumber);

        //    public User GetById(int id) =>
        //        _context.Users.Find(id);
        //}
        public User Login(string cardNumber)
        {
            return StaticDb.Users.FirstOrDefault(u => u.CardNumber == cardNumber);
        }

        public User GetById(int id)
        {
            return StaticDb.Users.FirstOrDefault(u => u.Id == id);
        }
    }
}
