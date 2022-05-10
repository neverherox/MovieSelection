using System.Net.Http.Json;
using MovieSelection.Client.Interfaces;
using MovieSelection.Models.Entities;
using MovieSelection.Models.RequestModels;

namespace MovieSelection.Client.Services
{
    public class MovieService : BaseService, IMovieService
    {
        public MovieService(IHttpClientFactory factory): base(factory)
        {
        }

        public async Task<IEnumerable<GetMovie>> GetMoviesAsync()
        {
            var movies = await PublicClient.GetFromJsonAsync<IEnumerable<GetMovie>>("movies");
            return movies;
        }

        public async Task<GetMovie> GetMovieAsync(int id)
        {
            var movie = await PublicClient.GetFromJsonAsync<GetMovie>($"movies/{id}");
            return movie;
        }

        public async Task<IEnumerable<Actor>> GetActorsAsync(int id)
        {
            var actors = await PublicClient.GetFromJsonAsync<IEnumerable<Actor>>($"movies/{id}/actors");
            return actors;
        }

        public async Task<IEnumerable<GetReview>> GetReviewsAsync(int id)
        {
            var reviews = await PublicClient.GetFromJsonAsync<IEnumerable<GetReview>>($"movies/{id}/reviews");
            return reviews;
        }

        public async Task<GetRate> GetRateAsync(int id)
        {
            var rate = await PublicClient.GetFromJsonAsync<GetRate>($"movies/{id}/rate");
            return rate;
        }

        public async Task<IEnumerable<string>> GetMovieNamesAsync()
        {
            var movieNames = await PublicClient.GetFromJsonAsync<IEnumerable<string>>("movie-names");
            return movieNames;
        }

        public async Task<IEnumerable<GetMovie>> GetHighlyRatedMoviesAsync(int top)
        {
            var movies = await PublicClient.GetFromJsonAsync<IEnumerable<GetMovie>>($"highly-rated/{top}");
            return movies;
        }

        public async Task<IEnumerable<GetMovie>> GetNoveltiesAsync(int top)
        {
            var movies = await PublicClient.GetFromJsonAsync<IEnumerable<GetMovie>>($"novelties/{top}");
            return movies;
        }
    }
}
