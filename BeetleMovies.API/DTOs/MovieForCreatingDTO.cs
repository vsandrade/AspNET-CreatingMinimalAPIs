namespace BeetleMovies.API;

public class MovieForCreatingDTO
{
  public required string Title { get; set; }
  public int Year { get; set; }
  public double Rating { get; set; }
}
