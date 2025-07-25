using VideoMovieRent.Services.Dtos;

namespace VideoMovieRent.Services.Services.Interfaces
{
    public interface IAdminService
    {
        bool Login(string username, string password);
        void CreateMovie(MovieDto dto);
        void UpdateMovie(MovieDetailsDto dto);
        void DeleteMovie(int id);
    }
}
