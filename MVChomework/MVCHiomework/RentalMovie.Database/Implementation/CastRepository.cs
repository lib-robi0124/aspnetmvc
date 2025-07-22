using RentalMovie.Database.Interfaces;
using RentalMovie.Domain;

namespace RentalMovie.Database.Implementation
{
    public class CastRepository : ICastRepository
    {
        public void Add(Cast entity)
        {
            throw new NotImplementedException();
        }

        public void AddCastToMovie(int movieId, int actorId)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Cast> GetAll()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Cast> GetAllCasts()
        {
            throw new NotImplementedException();
        }

        public Cast GetById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Cast> GetCastsByActorId(int actorId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Cast> GetCastsByMovieId(int movieId)
        {
            throw new NotImplementedException();
        }

        public void RemoveCastFromMovie(int movieId, int actorId)
        {
            throw new NotImplementedException();
        }

        public void Update(Cast entity)
        {
            throw new NotImplementedException();
        }
    }
}
