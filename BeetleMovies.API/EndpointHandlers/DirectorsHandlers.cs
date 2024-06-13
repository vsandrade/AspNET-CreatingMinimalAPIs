using AutoMapper;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace BeetleMovies.API;

public static class DirectorsHandlers
{
  public static async Task<Results<NotFound, Ok<IEnumerable<DirectorDTO>>>> GetDirectorsAsync (
  BeetleMoviesContext context,
  IMapper mapper,
  int moviesId)
  {
    var movieResult = await context.Movies.FirstOrDefaultAsync(x => x.Id == moviesId);
      if (movieResult == null)
        return TypedResults.NotFound();

    return TypedResults.Ok(mapper.Map<IEnumerable<DirectorDTO>>((await context.Movies
                        .Include(movie => movie.Directors)
                        .FirstOrDefaultAsync(movie => movie.Id == moviesId))?.Directors));
  }
}
