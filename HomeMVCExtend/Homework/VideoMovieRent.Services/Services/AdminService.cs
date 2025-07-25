using Microsoft.AspNetCore.Http;
using VideoMovieRent.DataAccess.Interfaces;
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

        public bool Login(string username, string password)
        {
            var admin = _adminRepository.GetByUsernameAndPassword(username, password);
            if (admin == null) return false;

            _httpContextAccessor.HttpContext?.Session.SetString("UserRole", "Admin");
            _httpContextAccessor.HttpContext?.Session.SetString("AdminUsername", admin.Username);

            return true;
        }
    }
}
