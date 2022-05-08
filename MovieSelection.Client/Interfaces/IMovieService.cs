﻿using MovieSelection.Models.Entities;
using MovieSelection.Models.RequestModels;

namespace MovieSelection.Client.Interfaces
{
    public interface IMovieService
    {
        Task<IEnumerable<GetMovie>> GetMoviesAsync();

        Task<GetMovie> GetMovieAsync(int id);

        Task<IEnumerable<Actor>> GetActorsAsync(int id);

        Task<IEnumerable<GetReview>> GetReviewsAsync(int id);

        Task<GetRate> GetRateAsync(int id);

        Task<IEnumerable<string>> GetMovieNamesAsync();
    }
}
