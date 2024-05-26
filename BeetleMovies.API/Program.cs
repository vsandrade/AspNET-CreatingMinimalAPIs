using BeetleMovies.API;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<BeetleMoviesContext>(
  o => o.UseSqlite(builder.Configuration["ConnectionStrings:BeetleMovieStr"])
);

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.Run();
