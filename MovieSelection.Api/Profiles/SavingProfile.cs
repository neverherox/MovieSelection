using AutoMapper;
using MovieSelection.Models.Entities;
using MovieSelection.Models.RequestModels;

namespace MovieSelection.Api.Profiles
{
    public class SavingProfile : Profile
    {
        public SavingProfile()
        {
            PostSavingProfile();
        }

        public void PostSavingProfile()
        {
            CreateMap<PostSaving, Saving>()
                .ForMember(dest => dest.UserId,
                    opt => opt.MapFrom(src => src.UserId))
                .ForMember(dest => dest.MovieId,
                    opt => opt.MapFrom(src => src.MovieId));
        }
    }
}
