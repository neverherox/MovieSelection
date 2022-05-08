using System.Net.Http.Json;
using MovieSelection.Client.Interfaces;
using MovieSelection.Models.RequestModels;

namespace MovieSelection.Client.Services
{
    public class GenreService : BaseService, IGenreService
    {
        public GenreService(IHttpClientFactory factory) : base(factory)
        {
        }

        public async Task<IEnumerable<GetGenre>> GetGenresAsync()
        {
            var genres = await PublicClient.GetFromJsonAsync<IEnumerable<GetGenre>>("genres");
            return genres;
        }
    }
}
