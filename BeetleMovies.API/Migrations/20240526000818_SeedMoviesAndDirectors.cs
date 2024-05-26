using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BeetleMovies.API.Migrations
{
    /// <inheritdoc />
    public partial class SeedMoviesAndDirectors : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Directors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 150, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Directors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Movies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Title = table.Column<string>(type: "TEXT", maxLength: 150, nullable: false),
                    Year = table.Column<int>(type: "INTEGER", nullable: false),
                    Rating = table.Column<double>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DirectorMovie",
                columns: table => new
                {
                    DirectorsId = table.Column<int>(type: "INTEGER", nullable: false),
                    MoviesId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DirectorMovie", x => new { x.DirectorsId, x.MoviesId });
                    table.ForeignKey(
                        name: "FK_DirectorMovie_Directors_DirectorsId",
                        column: x => x.DirectorsId,
                        principalTable: "Directors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DirectorMovie_Movies_MoviesId",
                        column: x => x.MoviesId,
                        principalTable: "Movies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Directors",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Brian De Palma" },
                    { 2, "John Lasseter" },
                    { 3, "Adrian Molina" },
                    { 4, "Lee Unkrich" },
                    { 5, "Brad Bird" },
                    { 6, "Peter Ramsey" },
                    { 7, "Bob Persichetti" },
                    { 8, "Rodney Rothman" },
                    { 9, "Makoto Shinkai" },
                    { 10, "Chris Sanders" },
                    { 11, "Dean DeBlois" },
                    { 12, "Angus MacLane" },
                    { 13, "David Fincher" },
                    { 14, "Anthony Russo" },
                    { 15, "Joe Russo" },
                    { 16, "Antoine Fuqua" }
                });

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "Id", "Rating", "Title", "Year" },
                values: new object[,]
                {
                    { 1, 7.0999999999999996, "Mission Impossible", 1996 },
                    { 2, 8.3000000000000007, "Toy Story", 1995 },
                    { 3, 8.4000000000000004, "Coco", 2017 },
                    { 4, 8.0999999999999996, "The Iron Giant", 1999 },
                    { 5, 8.4000000000000004, "Spider-Man - Into the spider-verse", 2018 },
                    { 6, 8.4000000000000004, "Your Name", 2016 },
                    { 7, 8.0999999999999996, "How to Train Your Dragon", 2010 },
                    { 8, 5.7000000000000002, "Lightyear", 2022 },
                    { 9, 7.7999999999999998, "The Girl with the Dragon Tattoo", 2011 },
                    { 10, 8.4000000000000004, "Avengers: Endgame", 2019 },
                    { 11, 7.2000000000000002, "The Equalizer", 2014 }
                });

            migrationBuilder.InsertData(
                table: "DirectorMovie",
                columns: new[] { "DirectorsId", "MoviesId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 2 },
                    { 3, 3 },
                    { 4, 3 },
                    { 5, 4 },
                    { 6, 5 },
                    { 7, 5 },
                    { 8, 5 },
                    { 9, 6 },
                    { 10, 7 },
                    { 11, 7 },
                    { 12, 8 },
                    { 13, 9 },
                    { 14, 10 },
                    { 15, 10 },
                    { 16, 11 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_DirectorMovie_MoviesId",
                table: "DirectorMovie",
                column: "MoviesId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DirectorMovie");

            migrationBuilder.DropTable(
                name: "Directors");

            migrationBuilder.DropTable(
                name: "Movies");
        }
    }
}
