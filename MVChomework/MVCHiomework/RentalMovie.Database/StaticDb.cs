using RentalMovie.Domain;
using RentalMovie.Domain.Enums;

namespace RentalMovie.Database
{
    public static class StaticDb
    {
        public static List<User> Users { get; set; }
        public static List<Movie> Movies { get; set; }
        public static List<Cast> Casts { get; set; }
        public static List<Rental> Rentals { get; set; }

        static StaticDb()
        {
            LoadUsers();
            LoadMovies();
            LoadCasts();
            LoadRentals();
        }
        private static void LoadUsers()
        {
            Users = new List<User>
            {
                new User {
                    Id = 1,
                    FullName = "Robert Ristovski",
                    CardNumber = "1234567890",
                    Age = 30,
                    CreatedOn = DateTime.Now,
                    IsSubscriptionExpired = false,
                    SubscriptionType = SubscriptionType.Yearly
                },
                new User {
                    Id = 2,
                    FullName = "John Doe",
                    CardNumber = "0987654321",
                    Age = 25,
                    CreatedOn = DateTime.Now,
                    IsSubscriptionExpired = true,
                    SubscriptionType = SubscriptionType.Monthly
                },
                new User {
                    Id = 3,
                    FullName = "Jane Smith",
                    CardNumber = "1122334455",
                    Age = 28,
                    CreatedOn = DateTime.Now,
                    IsSubscriptionExpired = false,
                    SubscriptionType = SubscriptionType.Premium
                },
                new User {
                    Id = 4,
                    FullName = "Alice Johnson",
                    CardNumber = "5566778899",
                    Age = 22,
                    CreatedOn = DateTime.Now,
                    IsSubscriptionExpired = false,
                    SubscriptionType = SubscriptionType.Basic
                }
            };
        }
        private static void LoadMovies()
        {
            Movies = new List<Movie>
            {
                new Movie {
                    Id = 1,
                    Title = "Inception",
                    Genre = Genre.SciFi,
                    Language = Language.English,
                    IsAvailable = true,
                    ReleaseDate = new DateTime(2010, 7, 16),
                    Length = 148,
                    AgeRestriction = 13,
                    Quantity = 5
                },
                new Movie {
                    Id = 2,
                    Title = "The Godfather",
                    Genre = Genre.Drama,
                    Language = Language.English,
                    IsAvailable = true,
                    ReleaseDate = new DateTime(1972, 3, 24),
                    Length = 175,
                    AgeRestriction = 18,
                    Quantity = 3
                },
                new Movie {
                    Id = 3,
                    Title = "Parasite",
                    Genre = Genre.Action,
                    Language = Language.Korean,
                    IsAvailable = true,
                    ReleaseDate = new DateTime(2019, 5, 30),
                    Length = 132,
                    AgeRestriction = 15,
                    Quantity = 4
                },
                new Movie {
                    Id = 4,
                    Title = "The Dark Knight",
                    Genre = Genre.Comedy,
                    Language = Language.English,
                    IsAvailable = true,
                    ReleaseDate = new DateTime(2008, 7, 18),
                    Length = 152,
                    AgeRestriction = 13,
                    Quantity = 6
                }
            };
        }
        private static void LoadCasts()
        {
            Casts = new List<Cast>
            {
                new Cast {
                    Id = 1,
                    MovieId = "1",
                    Name = "Leonardo DiCaprio",
                    Part = Part.Actor
                },
                new Cast {
                    Id = 2,
                    MovieId = "2",
                    Name = "Francis Ford Coppola",
                    Part = Part.Director
                },
                new Cast {
                    Id = 3,
                    MovieId = "3",
                    Name = "Hong Kyung-pyo",
                    Part = Part.Camera
                },
                new Cast {
                    Id = 4,
                    MovieId = "2",
                    Name = "Marlon Brando",
                    Part = Part.Actor
                }
            };
        }
        private static void LoadRentals()
        {
            Rentals = new List<Rental>
            {
                new Rental {
                    Id = 1,
                    UserId = 1,
                    MovieId = 1,
                    RentedOn = DateTime.Now.AddDays(-2),
                    ReturnedOn = DateTime.Now.AddDays(3)
                },
                new Rental {
                    Id = 2,
                    UserId = 2,
                    MovieId = 2,
                    RentedOn = DateTime.Now.AddDays(-5),
                    ReturnedOn = DateTime.Now.AddDays(1)
                },
                new Rental {
                    Id = 3,
                    UserId = 3,
                    MovieId = 3,
                    RentedOn = DateTime.Now.AddDays(-1),
                    ReturnedOn = DateTime.Now.AddDays(4)
                }
            };
        }

    }

}
