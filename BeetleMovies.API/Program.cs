using BeetleMovies.API;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<BeetleMoviesContext>(
  o => o.UseSqlite(builder.Configuration["ConnectionStrings:BeetleMovieStr"])
);

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

var app = builder.Build();

app.RegisterMoviesEndpoints();
app.RegisterDirectorsEndpoints();

app.Run();
