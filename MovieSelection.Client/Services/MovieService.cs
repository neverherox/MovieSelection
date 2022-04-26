using System.Net.Http.Json;
using MovieSelection.Client.Interfaces;
using MovieSelection.Models.Entities;

namespace MovieSelection.Client.Services
{
    public class MovieService : BaseService, IMovieService
    {
        public MovieService(IHttpClientFactory factory): base(factory)
        {
        }

        public async Task<IEnumerable<Movie>> GetMoviesAsync()
        {
            var movies = await PublicClient.GetFromJsonAsync<IEnumerable<Movie>>("movies");
            return movies;
        }

        public async Task<Movie> GetMovieAsync(int id)
        {
            var movie = await PublicClient.GetFromJsonAsync<Movie>($"movies/{id}");
            return movie;
        }

        public async Task<IEnumerable<Actor>> GetActorsAsync(int id)
        {
            var actors = await PublicClient.GetFromJsonAsync<IEnumerable<Actor>>($"movies/{id}/actors");
            return actors;
        }

        public async Task<IEnumerable<Review>> GetReviewsAsync(int id)
        {
            var reviews = await PublicClient.GetFromJsonAsync<IEnumerable<Review>>($"movies/{id}/reviews");
            return reviews;
        }
    }
}
