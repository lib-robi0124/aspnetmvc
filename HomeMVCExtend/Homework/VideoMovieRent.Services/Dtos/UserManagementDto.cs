namespace VideoMovieRent.Services.Dtos
{
    public class UserManagementDto
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string CardNumber { get; set; }
        public bool IsActive { get; set; }
        public DateTime LastLogin { get; set; }
    }
}
