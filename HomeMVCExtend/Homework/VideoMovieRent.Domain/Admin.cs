namespace VideoMovieRent.Domain
{
    public class Admin
    {
        public int Id { get; set; }
        public string Username { get; set; } = null!;
        public string Password { get; set; } = null!; // Store hashed in production!
    }
}
