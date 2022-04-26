using AutoMapper;
using MovieSelection.Models.RequestModels;
using MovieSelection.Models.Entities;

namespace MovieSelection.Api.Profiles
{
    public class MovieProfile : Profile
    {
        public MovieProfile()
        {
            PostMovieProfile();
        }

        public void PostMovieProfile()
        {
            CreateMap<PostMovie, Movie>()
                .ForMember(
                    dest => dest.Name,
                    opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Description,
                    opt => opt.MapFrom(src => src.Description))
                .ForMember(dest => dest.Year,
                    opt => opt.MapFrom(src => src.Year))
                .ForMember(dest => dest.CountryId,
                    opt => opt.MapFrom(src => src.CountryId))
                .ForMember(dest => dest.Image,
                    opt => opt.MapFrom(src => GetImage(src)));
        }

        private byte[] GetImage(PostMovie movie)
        {
            using (var ms = new MemoryStream())
            {
                movie.Image.CopyTo(ms);
                return ms.ToArray();
            }
        }
    }
}
