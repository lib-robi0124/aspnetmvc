using Azure;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.VisualBasic;
using RentalMovie.Database.Interfaces;
using RentalMovie.Domain;
using RentalMovie.Domain.Enums;
using System.Collections.Generic;

namespace RentalMovie.Database.Implementation
{
    public class MovieRespository : IMovieRepository
    {
        public IEnumerable<Movie> GetAll()
        {
            throw new NotImplementedException();
        } 
        public Movie GetById(int id)
        {
            throw new NotImplementedException();
        }
        public void Add(Movie entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }
        public IEnumerable<Movie> GetAvailableMovies()
        {
            throw new NotImplementedException();
        }
        public void Update(Movie entity)
        {
            throw new NotImplementedException();
        }
    }
}
