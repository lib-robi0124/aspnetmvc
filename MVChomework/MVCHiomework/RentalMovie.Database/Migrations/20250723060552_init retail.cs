using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace RentalMovie.Database.Migrations
{
    /// <inheritdoc />
    public partial class initretail : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Casts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MovieId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Part = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Casts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Movies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Genre = table.Column<int>(type: "int", nullable: false),
                    Language = table.Column<int>(type: "int", nullable: false),
                    IsAvailable = table.Column<bool>(type: "bit", nullable: false),
                    ReleaseDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Length = table.Column<TimeSpan>(type: "time", nullable: false),
                    AgeRestriction = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    ImagePath = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Rentals",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MovieId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    RentedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ReturnedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rentals", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Age = table.Column<int>(type: "int", nullable: false),
                    CardNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsSubscriptionExpired = table.Column<bool>(type: "bit", nullable: false),
                    SubscriptionType = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Casts",
                columns: new[] { "Id", "MovieId", "Name", "Part" },
                values: new object[,]
                {
                    { 1, 1, "Ken Watanabe", 0 },
                    { 2, 2, "Park Chan-wook", 1 },
                    { 3, 2, "Lee Byung-hun", 0 },
                    { 4, 3, "Michael B. Jordan", 2 },
                    { 5, 4, "Marion Cotillard", 0 },
                    { 6, 7, "Tom Hardy", 0 },
                    { 7, 8, "Jessica Chastain", 1 },
                    { 8, 9, "Donnie Yen", 0 },
                    { 9, 3, "Zoe Saldana", 2 },
                    { 10, 6, "Owen Wilson", 0 }
                });

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "Id", "AgeRestriction", "Genre", "ImagePath", "IsAvailable", "Language", "Length", "Quantity", "ReleaseDate", "Title" },
                values: new object[,]
                {
                    { 1, 13, 3, "/images/movies/sci-fi.jpg", true, 6, new TimeSpan(0, 2, 23, 0, 0), 5, new DateTime(2012, 10, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "Neon Shadows" },
                    { 2, 18, 6, "/images/movies/thriller.jpg", true, 2, new TimeSpan(0, 2, 12, 0, 0), 3, new DateTime(2019, 5, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Silent Forest" },
                    { 3, 13, 3, "/images/movies/sci-fi.jpg", false, 0, new TimeSpan(0, 2, 23, 0, 0), 0, new DateTime(2012, 4, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "Quantum Paradox" },
                    { 4, 10, 7, "/images/movies/adventure.jpg", true, 3, new TimeSpan(0, 2, 49, 0, 0), 4, new DateTime(2014, 11, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "Celestial Voyage" },
                    { 5, 18, 4, "/images/movies/horror.jpg", true, 1, new TimeSpan(0, 2, 26, 0, 0), 2, new DateTime(1980, 5, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "Whispers in the Dark" },
                    { 6, 12, 5, "/images/movies/romance.jpg", true, 3, new TimeSpan(0, 2, 2, 0, 0), 3, new DateTime(2001, 4, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Midnight in Paris" },
                    { 7, 13, 10, "/images/movies/mystery.jpg", false, 4, new TimeSpan(0, 1, 56, 0, 0), 0, new DateTime(1997, 12, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Forgotten Letter" },
                    { 8, 17, 4, "/images/movies/horror.jpg", true, 0, new TimeSpan(0, 1, 44, 0, 0), 6, new DateTime(2017, 2, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "Crimson Peak" },
                    { 9, 13, 0, "/images/movies/action.jpg", true, 8, new TimeSpan(0, 2, 28, 0, 0), 7, new DateTime(2010, 7, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "Rogue Agent" },
                    { 10, 15, 9, "/images/movies/fantasy.jpg", true, 1, new TimeSpan(0, 1, 58, 0, 0), 2, new DateTime(2006, 10, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Alchemist's Daughter" }
                });

            migrationBuilder.InsertData(
                table: "Rentals",
                columns: new[] { "Id", "MovieId", "RentedOn", "ReturnedOn", "UserId" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2025, 7, 13, 8, 5, 51, 140, DateTimeKind.Local).AddTicks(7905), new DateTime(2025, 7, 18, 8, 5, 51, 140, DateTimeKind.Local).AddTicks(7909), 1 },
                    { 2, 2, new DateTime(2025, 7, 15, 8, 5, 51, 140, DateTimeKind.Local).AddTicks(7916), new DateTime(2025, 7, 21, 8, 5, 51, 140, DateTimeKind.Local).AddTicks(7917), 2 },
                    { 3, 3, new DateTime(2025, 7, 16, 8, 5, 51, 140, DateTimeKind.Local).AddTicks(7919), new DateTime(2025, 7, 22, 8, 5, 51, 140, DateTimeKind.Local).AddTicks(7920), 3 },
                    { 4, 4, new DateTime(2025, 7, 18, 8, 5, 51, 140, DateTimeKind.Local).AddTicks(7922), new DateTime(2025, 7, 23, 8, 5, 51, 140, DateTimeKind.Local).AddTicks(7923), 4 },
                    { 5, 5, new DateTime(2025, 7, 11, 8, 5, 51, 140, DateTimeKind.Local).AddTicks(7925), new DateTime(2025, 7, 16, 8, 5, 51, 140, DateTimeKind.Local).AddTicks(7926), 5 },
                    { 6, 6, new DateTime(2025, 7, 20, 8, 5, 51, 140, DateTimeKind.Local).AddTicks(7928), new DateTime(2025, 7, 23, 8, 5, 51, 140, DateTimeKind.Local).AddTicks(7929), 6 },
                    { 7, 7, new DateTime(2025, 7, 19, 8, 5, 51, 140, DateTimeKind.Local).AddTicks(7931), new DateTime(2025, 7, 22, 8, 5, 51, 140, DateTimeKind.Local).AddTicks(7932), 7 },
                    { 8, 8, new DateTime(2025, 7, 21, 8, 5, 51, 140, DateTimeKind.Local).AddTicks(7933), new DateTime(2025, 7, 23, 8, 5, 51, 140, DateTimeKind.Local).AddTicks(7935), 8 },
                    { 9, 9, new DateTime(2025, 7, 17, 8, 5, 51, 140, DateTimeKind.Local).AddTicks(7936), new DateTime(2025, 7, 21, 8, 5, 51, 140, DateTimeKind.Local).AddTicks(7938), 9 },
                    { 10, 10, new DateTime(2025, 7, 22, 8, 5, 51, 140, DateTimeKind.Local).AddTicks(7939), new DateTime(2025, 7, 23, 8, 5, 51, 140, DateTimeKind.Local).AddTicks(7940), 10 }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Age", "CardNumber", "CreatedOn", "FullName", "IsSubscriptionExpired", "SubscriptionType" },
                values: new object[,]
                {
                    { 1, 25, "1111-2222", new DateTime(2025, 1, 23, 8, 5, 51, 140, DateTimeKind.Local).AddTicks(7703), "Emma Watson", false, 0 },
                    { 2, 30, "2222-3333", new DateTime(2024, 11, 23, 8, 5, 51, 140, DateTimeKind.Local).AddTicks(7752), "James Wilson", true, 1 },
                    { 3, 22, "3333-4444", new DateTime(2024, 7, 23, 8, 5, 51, 140, DateTimeKind.Local).AddTicks(7758), "Olivia Martinez", false, 0 },
                    { 4, 28, "4444-5555", new DateTime(2025, 4, 23, 8, 5, 51, 140, DateTimeKind.Local).AddTicks(7760), "Liam Anderson", false, 1 },
                    { 5, 35, "5555-6666", new DateTime(2023, 7, 23, 8, 5, 51, 140, DateTimeKind.Local).AddTicks(7763), "Sophia Garcia", true, 0 },
                    { 6, 40, "6666-7777", new DateTime(2024, 9, 23, 8, 5, 51, 140, DateTimeKind.Local).AddTicks(7766), "Noah Taylor", false, 1 },
                    { 7, 29, "7777-8888", new DateTime(2025, 2, 23, 8, 5, 51, 140, DateTimeKind.Local).AddTicks(7768), "Ava Lopez", false, 0 },
                    { 8, 33, "8888-9999", new DateTime(2025, 6, 23, 8, 5, 51, 140, DateTimeKind.Local).AddTicks(7770), "William Hernandez", true, 1 },
                    { 9, 21, "9999-0000", new DateTime(2024, 12, 23, 8, 5, 51, 140, DateTimeKind.Local).AddTicks(7772), "Mia Gonzalez", false, 0 },
                    { 10, 27, "0000-1111", new DateTime(2025, 3, 23, 8, 5, 51, 140, DateTimeKind.Local).AddTicks(7775), "Benjamin Clark", true, 1 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Casts");

            migrationBuilder.DropTable(
                name: "Movies");

            migrationBuilder.DropTable(
                name: "Rentals");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
