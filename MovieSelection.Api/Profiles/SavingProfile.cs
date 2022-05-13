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
            PutSavingProfile();
        }

        public void PostSavingProfile()
        {
            CreateMap<PostSaving, Saving>()
                .ForMember(dest => dest.UserId,
                    opt => opt.MapFrom(src => src.UserId))
                .ForMember(dest => dest.MovieId,
                    opt => opt.MapFrom(src => src.MovieId));
        }

        public void PutSavingProfile()
        {
            CreateMap<PutSaving, Saving>()
                .ForMember(dest => dest.Id,
                    opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.IsWatched,
                    opt => opt.MapFrom(src => src.IsWatched))
                .ForMember(dest => dest.MovieId,
                    opt => opt.MapFrom(src => src.MovieId))
                .ForMember(dest => dest.UserId,
                    opt => opt.MapFrom(src => src.UserId));
        }
    }
}
