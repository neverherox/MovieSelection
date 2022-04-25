using AutoMapper;
using MovieSelection.Api.Models;
using MovieSelection.Models;

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
                    opt => opt.MapFrom(src => GetImage(src)));
        }

        private byte[] GetImage(PostActor actor)
        {
            using (var ms = new MemoryStream())
            {
                actor.Image.CopyTo(ms);
                return ms.ToArray();
            }
        }
    }
}
