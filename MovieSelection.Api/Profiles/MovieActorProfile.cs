using AutoMapper;
using MovieSelection.Models.Entities;
using MovieSelection.Models.RequestModels;

namespace MovieSelection.Api.Profiles
{
    public class MovieActorProfile : Profile
    {
        public MovieActorProfile()
        {
            PostMovieActorProfile();
        }

        public void PostMovieActorProfile()
        {
            CreateMap<PostMovieActor, MovieActor>()
                .ForMember(
                    dest => dest.MovieId,
                    opt => opt.MapFrom(src => src.MovieId))
                .ForMember(dest => dest.ActorId,
                    opt => opt.MapFrom(src => src.ActorId));
        }
    }
}
