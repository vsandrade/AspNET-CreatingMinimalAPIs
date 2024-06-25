using AutoMapper;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BeetleMovies.API;

public static class MoviesHandlers
{
  public static async Task<Results<NoContent, Ok<IEnumerable<MovieDTO>>>> GetMoviesAsync (
    BeetleMoviesContext context,
    IMapper mapper,
    ILogger<MovieDTO> logger,
    [FromQuery(Name = "movieName")] string? title)
  {
    var movieEntity = await context.Movies
                                  .Where(x => title == null ||
                                          x.Title.ToLower().Contains(title.ToLower()))
                                  .ToListAsync();

    if (movieEntity.Count <= 0 || movieEntity == null)
    {
      logger.LogInformation($"Movie not found. Param: {title}");
      return TypedResults.NoContent();
    }
    else
    {
      logger.LogInformation($"Movie found. Return: {movieEntity[0].Title}");
      return TypedResults.Ok(mapper.Map<IEnumerable<MovieDTO>>(movieEntity));
    }
  }

  public static async Task<Results<NotFound, Ok<MovieDTO>>> GetMoviesById (
    BeetleMoviesContext context,
    IMapper mapper,
    int moviesId)
  {
    var movieResult = await context.Movies.FirstOrDefaultAsync(x => x.Id == moviesId);
      if (movieResult == null)
        return TypedResults.NotFound();

    return TypedResults.Ok(mapper.Map<MovieDTO>(movieResult));
  }

  public static async Task<CreatedAtRoute<MovieDTO>> CreateMoviesAsync (
    BeetleMoviesContext context,
    IMapper mapper,
    [FromBody] MovieForCreatingDTO movieForCreatingDTO)
  {
    var movie = mapper.Map<Movie>(movieForCreatingDTO);
    context.Add(movie);
    await context.SaveChangesAsync();

    var movieToReturn = mapper.Map<MovieDTO>(movie);

    return TypedResults.CreatedAtRoute(movieToReturn, "GetMovies", new { moviesId = movieToReturn.Id });
  }

  public static async Task<Results<NotFound, Ok>> UpdateMoviesAsync (
    BeetleMoviesContext context,
    IMapper mapper,
    int moviesId,
    [FromBody] MovieForUpdatingDTO movieForUpdatingDTO)
  {
    var movie = await context.Movies.FirstOrDefaultAsync(x => x.Id == moviesId);
    if (movie == null)
      return TypedResults.NotFound();

    mapper.Map(movieForUpdatingDTO, movie);

    await context.SaveChangesAsync();

    return TypedResults.Ok();
  }

  public static async Task<Results<NotFound, NoContent>> DeleteMoviesAsync(
    BeetleMoviesContext context,
    int moviesId)
  {
    var movie = await context.Movies.FirstOrDefaultAsync(x => x.Id == moviesId);
    if (movie == null)
      return TypedResults.NotFound();

    context.Movies.Remove(movie);

    await context.SaveChangesAsync();

    return TypedResults.NoContent();
  }
}
