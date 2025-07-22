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
        //- **View Movies**: Create a page that displays a list or grid of all the movies.
        //    Each item should show basic information about the movie, such as the title and genre.
        //    You could also show whether the movie is currently available for rent.

        //- **Movie Details**: Each movie in the list should be clickable and lead to a detailed page for that movie. 
        //    This page should display all the information about the movie, such as the title, genre, language, release date, 
        //length, age restriction, and quantity available.
        public IEnumerable<Movie> GetAll()
        {
            return StaticDb.Movies;
        } 
        public Movie GetById(int id)
        {
            return StaticDb.Movies.FirstOrDefault(m => m.Id == id);
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
