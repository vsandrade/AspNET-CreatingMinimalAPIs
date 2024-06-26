using Microsoft.AspNetCore.Identity;

namespace BeetleMovies.API;

public static class EndpointRouteBuilderExtensions
{
  public static void RegisterMoviesEndpoints(this IEndpointRouteBuilder endpointRouteBuilder)
  {
    endpointRouteBuilder.MapGroup("/identity/").MapIdentityApi<IdentityUser>();

    endpointRouteBuilder.MapGet("GetMovie/{movieId:int}",
      (int movieId) => $"the movie {movieId} was perfect!")
      .WithOpenApi(operataion =>
      {
        operataion.Deprecated = true;
        return operataion;
      })
      .WithSummary("This endpoint is deprecated and it'll be removed in our version 2.0")
      .WithDescription("Please, use the endpoint /movies/{moviesId} to avoid future problems.");


    var moviesGroups = endpointRouteBuilder.MapGroup("/movies")
      .RequireAuthorization();
    var moviesGroupsWithId = moviesGroups.MapGroup("/{moviesId:int}");

    var moviesGroupsWithIdFilters = endpointRouteBuilder.MapGroup("/movies/{moviesId:int}")
      .RequireAuthorization()
      .AddEndpointFilter(new PerfectMoviesAreLockedFilter(2))
      .AddEndpointFilter(new PerfectMoviesAreLockedFilter(5));

    moviesGroups.MapGet("", MoviesHandlers.GetMoviesAsync);

    moviesGroups.MapPost("", MoviesHandlers.CreateMoviesAsync)
      .AddEndpointFilter<ValidateAnnotationFilter>();

    moviesGroupsWithId.MapGet("", MoviesHandlers.GetMoviesById).WithName("GetMovies")
      .RequireAuthorization("RequireAdminFromBrazil")
      .WithOpenApi()
      .WithSummary("This endpoint will return movies by id");

    moviesGroupsWithIdFilters.MapPut("", MoviesHandlers.UpdateMoviesAsync);

    moviesGroupsWithIdFilters.MapDelete("", MoviesHandlers.DeleteMoviesAsync)
      .AddEndpointFilter<LogNotFoundResponseFilter>();
  }

  public static void RegisterDirectorsEndpoints(this IEndpointRouteBuilder endpointRouteBuilder)
  {
    var directorsGroups = endpointRouteBuilder.MapGroup("/movies/{moviesId:int}/directors")
      .RequireAuthorization();

    directorsGroups.MapGet("", DirectorsHandlers.GetDirectorsAsync);
    directorsGroups.MapPost("", () => {
      throw new NotImplementedException();
    });
  }
}
