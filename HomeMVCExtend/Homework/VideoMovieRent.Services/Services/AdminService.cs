using Microsoft.AspNetCore.Http;
using VideoMovieRent.DataAccess.Interfaces;
using VideoMovieRent.Domain;
using VideoMovieRent.Services.Dtos;
using VideoMovieRent.Services.Services.Interfaces;

namespace VideoMovieRent.Services.Services
{
    public class AdminService : IAdminService
    {
        private readonly IAdminRepository _adminRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public AdminService(IAdminRepository adminRepository, IHttpContextAccessor httpContextAccessor)
        {
            _adminRepository = adminRepository;
            _httpContextAccessor = httpContextAccessor;
        }

        public void CreateMovie(MovieDto dto)
        {
            var movie = new Movie
            {
                Title = dto.Title,
                Genre = dto.Genre,
                Language = dto.Language,
                Quantity = 1, // Default quantity for new movies
                ImagePath = dto.ImagePath
            };
            _adminRepository.Create(movie);
        }

        public void DeleteMovie(int id)
        {
            _adminRepository.Delete(id);
        }

        public bool Login(string username, string password)
        {
            var admin = _adminRepository.GetByUsernameAndPassword(username, password);
            if (admin == null) return false;

            _httpContextAccessor.HttpContext?.Session.SetString("AdminUsername", admin.Username);

            return true;
        }

        public void UpdateMovie(MovieDetailsDto entity)
        {
            var movie = new Movie
            {
                Id = entity.Id,
                Title = entity.Title,
                Genre = entity.Genre,
                Length = entity.Length,
                AgeRestriction = entity.AgeRestriction,
                Quantity = entity.Quantity,
                ReleaseDate = entity.ReleaseDate,
                Language = entity.Language,
                ImagePath = entity.ImagePath
            };
        }
    }
}
