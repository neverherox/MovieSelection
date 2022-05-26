using AutoMapper;
using MovieSelection.Models.RequestModels;
using MovieSelection.Models.Entities;

namespace MovieSelection.Api.Profiles
{
    public class ActorProfile : Profile
    {
        public ActorProfile()
        {
            PostActorProfile();
        }

        public void PostActorProfile()
        {
            CreateMap<PostActor, Actor>()
                .ForMember(
                    dest => dest.FirstName,
                    opt => opt.MapFrom(src => src.FirstName))
                .ForMember(dest => dest.LastName,
                    opt => opt.MapFrom(src => src.LastName))
                .ForMember(dest => dest.Image,
                    opt => opt.MapFrom(src => src.Image));
        }
    }
}
