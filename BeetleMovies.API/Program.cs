using System.Net;
using BeetleMovies.API;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<BeetleMoviesContext>(
  o => o.UseSqlite(builder.Configuration["ConnectionStrings:BeetleMovieStr"])
);

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddProblemDetails();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
  app.UseExceptionHandler();

  //Referente of Details that you can do.
  // app.UseExceptionHandler(configureApplicationBuilder =>
  // {
  //   configureApplicationBuilder.Run(async context =>
  //   {
  //     context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
  //     context.Response.ContentType = "text/html";
  //     await context.Response.WriteAsync("An unexpected problem happened.");
  //   });
  // });
}

app.RegisterMoviesEndpoints();
app.RegisterDirectorsEndpoints();

app.Run();
