using AutoMapper;
using MovieSelection.Models.Entities;
using MovieSelection.Models.RequestModels;

namespace MovieSelection.Api.Profiles
{
    public class MovieGenreProfile : Profile
    {
        public MovieGenreProfile()
        {
            PostMovieGenreProfile();
        }

        public void PostMovieGenreProfile()
        {
            CreateMap<PostMovieGenre, MovieGenre>()
                .ForMember(
                    dest => dest.MovieId,
                    opt => opt.MapFrom(src => src.MovieId))
                .ForMember(dest => dest.GenreId,
                    opt => opt.MapFrom(src => src.GenreId));
        }
    }
}
