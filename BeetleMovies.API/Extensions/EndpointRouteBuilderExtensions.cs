namespace BeetleMovies.API;

public static class EndpointRouteBuilderExtensions
{
  public static void RegisterMoviesEndpoints(this IEndpointRouteBuilder endpointRouteBuilder)
  {
    var moviesGroups = endpointRouteBuilder.MapGroup("/movies");
    var moviesGroupsWithId = moviesGroups.MapGroup("/{moviesId:int}");

    var moviesGroupsWithIdFilters = endpointRouteBuilder.MapGroup("/movies/{moviesId:int}")
      .AddEndpointFilter(new PerfectMoviesAreLockedFilter(2))
      .AddEndpointFilter(new PerfectMoviesAreLockedFilter(5));

    moviesGroups.MapGet("", MoviesHandlers.GetMoviesAsync);

    moviesGroups.MapPost("", MoviesHandlers.CreateMoviesAsync)
      .AddEndpointFilter<ValidateAnnotationFilter>();

    moviesGroupsWithId.MapGet("", MoviesHandlers.GetMoviesById).WithName("GetMovies");

    moviesGroupsWithIdFilters.MapPut("", MoviesHandlers.UpdateMoviesAsync);

    moviesGroupsWithIdFilters.MapDelete("", MoviesHandlers.DeleteMoviesAsync)
      .AddEndpointFilter<LogNotFoundResponseFilter>();
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
