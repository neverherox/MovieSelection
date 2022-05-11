using AutoMapper;
using MovieSelection.Models.Entities;
using MovieSelection.Models.RequestModels;

namespace MovieSelection.Api.Profiles
{
    public class RateProfile : Profile
    {
        public RateProfile()
        {
            PostRateProfile();
            PutRateProfile();
        }

        public void PostRateProfile()
        {
            CreateMap<PostRate, Rate>()
                .ForMember(
                    dest => dest.Directing,
                    opt => opt.MapFrom(src => src.Directing))
                .ForMember(
                    dest => dest.Entertainment,
                    opt => opt.MapFrom(src => src.Entertainment))
                .ForMember(
                    dest => dest.Actors,
                    opt => opt.MapFrom(src => src.Actors))
                .ForMember(
                    dest => dest.Plot,
                    opt => opt.MapFrom(src => src.Plot))
                .ForMember(
                    dest => dest.Value,
                    opt => opt.MapFrom(src => src.Value))
                .ForMember(
                    dest => dest.MovieId,
                    opt => opt.MapFrom(src => src.MovieId))
                .ForMember(
                    dest => dest.UserId,
                    opt => opt.MapFrom(src => src.UserId));
        }

        public void PutRateProfile()
        {
            CreateMap<PutRate, Rate>()
                .ForMember(
                    dest => dest.Id,
                    opt => opt.MapFrom(src => src.Id))
                .ForMember(
                    dest => dest.Directing,
                    opt => opt.MapFrom(src => src.Directing))
                .ForMember(
                    dest => dest.Entertainment,
                    opt => opt.MapFrom(src => src.Entertainment))
                .ForMember(
                    dest => dest.Actors,
                    opt => opt.MapFrom(src => src.Actors))
                .ForMember(
                    dest => dest.Plot,
                    opt => opt.MapFrom(src => src.Plot))
                .ForMember(
                    dest => dest.Value,
                    opt => opt.MapFrom(src => src.Value))
                .ForMember(
                    dest => dest.MovieId,
                    opt => opt.MapFrom(src => src.MovieId))
                .ForMember(
                    dest => dest.UserId,
                    opt => opt.MapFrom(src => src.UserId));
        }
    }
}
