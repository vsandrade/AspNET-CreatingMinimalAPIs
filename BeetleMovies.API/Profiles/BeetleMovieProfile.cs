using AutoMapper;

namespace BeetleMovies.API;

public class BeetleMovieProfile : Profile
{
  public BeetleMovieProfile()
  {
    CreateMap<Movie, MovieDTO>().ReverseMap();
    CreateMap<Movie, MovieForCreatingDTO>().ReverseMap();
    CreateMap<Movie, MovieForUpdatingDTO>().ReverseMap();
    CreateMap<Director, DirectorDTO>()
      .ForMember(d => d.MovieId,
                 o => o.MapFrom(d => d.Movies.First().Id));
  }
}
