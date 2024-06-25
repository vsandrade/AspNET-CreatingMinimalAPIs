namespace BeetleMovies.API;

public static class EndpointRouteBuilderExtensions
{
  public static void RegisterMoviesEndpoints(this IEndpointRouteBuilder endpointRouteBuilder)
  {
    var moviesGroups = endpointRouteBuilder.MapGroup("/movies");
    var moviesGroupsWithId = moviesGroups.MapGroup("/{moviesId:int}");

    moviesGroups.MapGet("", MoviesHandlers.GetMoviesAsync);

    moviesGroups.MapPost("", MoviesHandlers.CreateMoviesAsync);

    moviesGroupsWithId.MapGet("", MoviesHandlers.GetMoviesById).WithName("GetMovies");

    moviesGroupsWithId.MapPut("", MoviesHandlers.UpdateMoviesAsync);

    moviesGroupsWithId.MapDelete("", MoviesHandlers.DeleteMoviesAsync);
  }

  public static void RegisterDirectorsEndpoints(this IEndpointRouteBuilder endpointRouteBuilder)
  {
    var directorsGroups = endpointRouteBuilder.MapGroup("/movies/{moviesId:int}/directors");
    directorsGroups.MapGet("", DirectorsHandlers.GetDirectorsAsync);
    directorsGroups.MapPost("", () => {
      throw new NotImplementedException();
    });
  }
}
