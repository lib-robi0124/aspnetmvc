using Microsoft.VisualBasic;
using System.Collections.Generic;

namespace MovieRentalApp.Dtos
{
    // ** View Movies**: Create a page that displays a list
    // or grid of all the movies.Each item should show basic information about the movie,
    // such as the title and genre.You could also show whether the movie is currently available for rent.

    //**Movie Details**: Each movie in the list should be clickable
    //and lead to a detailed page for that movie.
    //This page should display all the information about the movie,
    //such as the title, genre, language, release date, length, age restriction, and quantity available.
    public class MovieDto
    {
        public string Title { get; set; }
        public string Genre { get; set; }
        public string Language { get; set; }
        public bool IsAvailable { get; set; }
    }
}
