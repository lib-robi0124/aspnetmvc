using RentalMovie.Domain;

namespace RentalMovie.Database.Interfaces
{
    public interface ICastRepository : IRepository<Cast>
    {
        IEnumerable<Cast> GetCastsByMovieId(int movieId);
        IEnumerable<Cast> GetCastsByActorId(int actorId);
        void AddCastToMovie(int movieId, int actorId);
        void RemoveCastFromMovie(int movieId, int actorId);
        IEnumerable<Cast> GetAllCasts();
    }
}
