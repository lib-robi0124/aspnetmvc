using VideoMovieRent.Domain;

namespace VideoMovieRent.DataAccess.Interfaces
{
    public interface IAdminRepository
    {
        Admin? GetByUsernameAndPassword(string username, string password);
    }
}
