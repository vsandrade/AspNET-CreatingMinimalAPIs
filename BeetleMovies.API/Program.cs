using BeetleMovies.API;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<BeetleMoviesContext>(
  o => o.UseSqlite(builder.Configuration["ConnectionStrings:BeetleMovieStr"])
);

builder.Services.AddIdentityApiEndpoints<IdentityUser>()
  .AddEntityFrameworkStores<BeetleMoviesContext>();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddProblemDetails();

builder.Services.AddAuthentication().AddJwtBearer();
builder.Services.AddAuthorization();

builder.Services.AddAuthorizationBuilder()
  .AddPolicy("RequireAdminFromBrazil", policy => 
    policy
      .RequireRole("admin")
      .RequireClaim("country", "Brazil"));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options => {
  options.AddSecurityDefinition("TakenAuthMovies",
    new() 
    {
      Name = "Authorization",
      Description = "Token based on Authorization and Authentication",
      Type = SecuritySchemeType.Http,
      Scheme = "Bearer",
      In = ParameterLocation.Header
    }
  );
  options.AddSecurityRequirement(new() 
  {
      {
        new() {
          Reference = new OpenApiReference {
            Type = ReferenceType.SecurityScheme,
            Id = "TakenAuthMovies"
          }
        }, new List<string>()
      }
    }
  );
});

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
  app.UseExceptionHandler();
}
else
{
  app.UseSwagger();
  app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.RegisterMoviesEndpoints();
app.RegisterDirectorsEndpoints();

app.Run();
