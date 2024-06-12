using System.Text.Json.Serialization;
using AutoMapper;
using BeetleMovies.API;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<BeetleMoviesContext>(
  o => o.UseSqlite(builder.Configuration["ConnectionStrings:BeetleMovieStr"])
);

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

var app = builder.Build();

var moviesGroups = app.MapGroup("/movies");
var moviesGroupsWithId = moviesGroups.MapGroup("/{moviesId:int}");
var directorsGroups = moviesGroupsWithId.MapGroup("/directors");

moviesGroups.MapGet("", async Task<Results<NoContent, Ok<IEnumerable<MovieDTO>>>> (
  BeetleMoviesContext context,
  IMapper mapper,
  [FromQuery(Name = "movieName")] string? title
) =>
{
  var movieEntity = await context.Movies
                                 .Where(x => title == null ||
                                        x.Title.ToLower().Contains(title.ToLower()))
                                 .ToListAsync();

  if (movieEntity.Count <= 0 || movieEntity == null)
    return TypedResults.NoContent();
  else
    return TypedResults.Ok(mapper.Map<IEnumerable<MovieDTO>>(movieEntity));
});

moviesGroups.MapPost("", async (
  BeetleMoviesContext context,
  IMapper mapper,
  // LinkGenerator linkGenerator,
  // HttpContext httpContext,
  [FromBody] MovieForCreatingDTO movieForCreatingDTO) =>
{
  var movie = mapper.Map<Movie>(movieForCreatingDTO);
  context.Add(movie);
  await context.SaveChangesAsync();

  var movieToReturn = mapper.Map<MovieDTO>(movie);

  return TypedResults.CreatedAtRoute(movieToReturn, "GetMovies", new { moviesId = movieToReturn.Id });

  //This is only a reference to my students.
  // var linkToReturn = linkGenerator.GetUriByName(
  //   httpContext, 
  //   "GetMovies", 
  //   new { id = movieToReturn.Id});

  // return TypedResults.Created( linkToReturn, movieToReturn);
});

directorsGroups.MapGet("", async (
  BeetleMoviesContext context,
  IMapper mapper,
  int moviesId
) =>
{
  return mapper.Map<IEnumerable<DirectorDTO>>((await context.Movies
                      .Include(movie => movie.Directors)
                      .FirstOrDefaultAsync(movie => movie.Id == moviesId))?.Directors);
});

moviesGroupsWithId.MapGet("", async (
  BeetleMoviesContext context,
  IMapper mapper,
  int moviesId
) =>
{
  return mapper.Map<MovieDTO>(await context.Movies.FirstOrDefaultAsync(x => x.Id == moviesId));
}).WithName("GetMovies");

moviesGroupsWithId.MapPut("", async Task<Results<NotFound, Ok>> (
  BeetleMoviesContext context,
  IMapper mapper,
  int moviesId,
  [FromBody] MovieForUpdatingDTO movieForUpdatingDTO
) =>
{
  var movie = await context.Movies.FirstOrDefaultAsync(x => x.Id == moviesId);
  if (movie == null)
    return TypedResults.NotFound();

  mapper.Map(movieForUpdatingDTO, movie);

  await context.SaveChangesAsync();

  return TypedResults.Ok();
});

moviesGroupsWithId.MapDelete("", async Task<Results<NotFound, NoContent>> (
  BeetleMoviesContext context,
  int moviesId
) =>
{
  var movie = await context.Movies.FirstOrDefaultAsync(x => x.Id == moviesId);
  if (movie == null)
    return TypedResults.NotFound();

  context.Movies.Remove(movie);

  await context.SaveChangesAsync();

  return TypedResults.NoContent();
});

app.Run();
