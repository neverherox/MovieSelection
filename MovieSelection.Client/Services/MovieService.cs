﻿using System.Net.Http.Json;
using MovieSelection.Client.Interfaces;
using MovieSelection.Models;

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
    }
}
