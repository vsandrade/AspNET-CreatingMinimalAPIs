namespace BeetleMovies.API;

public class MovieForUpdatingDTO
{
  public int Id { get; set; }
  public required string Title { get; set; }
  public int Year { get; set; }
  public double Rating { get; set; }
}
