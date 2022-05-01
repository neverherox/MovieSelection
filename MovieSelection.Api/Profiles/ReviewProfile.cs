using AutoMapper;
using MovieSelection.Models.Entities;
using MovieSelection.Models.RequestModels;

namespace MovieSelection.Api.Profiles
{
    public class ReviewProfile : Profile
    {
        public ReviewProfile()
        {
            PostReviewProfile();
        }

        public void PostReviewProfile()
        {
            CreateMap<PostReview, Review>()
                .ForMember(
                    dest => dest.Text,
                    opt => opt.MapFrom(src => src.Text))
                .ForMember(dest => dest.MovieId,
                    opt => opt.MapFrom(src => src.MovieId))
                .ForMember(dest => dest.UserId,
                    opt => opt.MapFrom(src => src.UserId))
                .ForMember(dest => dest.ReviewDate,
                    opt => opt.MapFrom(src => DateTime.UtcNow));
        }
    }
}
