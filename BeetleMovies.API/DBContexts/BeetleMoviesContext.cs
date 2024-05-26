using Microsoft.EntityFrameworkCore;

namespace BeetleMovies.API;

public class BeetleMoviesContext(DbContextOptions<BeetleMoviesContext> options) : DbContext(options) 
{
  public DbSet<Movie> Movies { get; set; }
  public DbSet<Director> Directors { get; set; }

  override protected void OnModelCreating(ModelBuilder modelBuilder)
  {
    base.OnModelCreating(modelBuilder);

    modelBuilder.Entity<Director>().HasData(
        new Director { Id = 1, Name = "Brian De Palma" },
        new Director { Id = 2, Name = "John Lasseter" },
        new Director { Id = 3, Name = "Adrian Molina" },
        new Director { Id = 4, Name = "Lee Unkrich" },
        new Director { Id = 5, Name = "Brad Bird" },
        new Director { Id = 6, Name = "Peter Ramsey" },
        new Director { Id = 7, Name = "Bob Persichetti" },
        new Director { Id = 8, Name = "Rodney Rothman" },
        new Director { Id = 9, Name = "Makoto Shinkai" },
        new Director { Id = 10, Name = "Chris Sanders" },
        new Director { Id = 11, Name = "Dean DeBlois" },
        new Director { Id = 12, Name = "Angus MacLane" },
        new Director { Id = 13, Name = "David Fincher" },
        new Director { Id = 14, Name = "Anthony Russo" },
        new Director { Id = 15, Name = "Joe Russo" },
        new Director { Id = 16, Name = "Antoine Fuqua" }
    );

    modelBuilder.Entity<Movie>().HasData(
        new Movie { Id = 1, Title = "Mission Impossible", Year = 1996, Rating = 7.1 },
        new Movie { Id = 2, Title = "Toy Story", Year = 1995, Rating = 8.3 },
        new Movie { Id = 3, Title = "Coco", Year = 2017, Rating = 8.4 },
        new Movie { Id = 4, Title = "The Iron Giant", Year = 1999, Rating = 8.1 },
        new Movie { Id = 5, Title = "Spider-Man - Into the spider-verse", Year = 2018, Rating = 8.4 },
        new Movie { Id = 6, Title = "Your Name", Year = 2016, Rating = 8.4 },
        new Movie { Id = 7, Title = "How to Train Your Dragon", Year = 2010, Rating = 8.1 },
        new Movie { Id = 8, Title = "Lightyear", Year = 2022, Rating = 5.7 },
        new Movie { Id = 9, Title = "The Girl with the Dragon Tattoo", Year = 2011, Rating = 7.8 },
        new Movie { Id = 10, Title = "Avengers: Endgame", Year = 2019, Rating = 8.4 },
        new Movie { Id = 11, Title = "The Equalizer", Year = 2014, Rating = 7.2 }
    );

    modelBuilder.Entity<Movie>()
        .HasMany(m => m.Directors)
        .WithMany(d => d.Movies)
        .UsingEntity(j => j.HasData(
            new { MoviesId = 1, DirectorsId = 1 },
            new { MoviesId = 2, DirectorsId = 2 },
            new { MoviesId = 3, DirectorsId = 3 },
            new { MoviesId = 3, DirectorsId = 4 },
            new { MoviesId = 4, DirectorsId = 5 },
            new { MoviesId = 5, DirectorsId = 6 },
            new { MoviesId = 5, DirectorsId = 7 },
            new { MoviesId = 5, DirectorsId = 8 },
            new { MoviesId = 6, DirectorsId = 9 },
            new { MoviesId = 7, DirectorsId = 10 },
            new { MoviesId = 7, DirectorsId = 11 },
            new { MoviesId = 8, DirectorsId = 12 },
            new { MoviesId = 9, DirectorsId = 13 },
            new { MoviesId = 10, DirectorsId = 14 },
            new { MoviesId = 10, DirectorsId = 15 },
            new { MoviesId = 11, DirectorsId = 16 }
        ));
  }
}
