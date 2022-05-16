using System.Net.Http.Json;
using MovieSelection.Client.Interfaces;
using MovieSelection.Models.Entities;
using MovieSelection.Models.RequestModels;

namespace MovieSelection.Client.Services
{
    public class RateService : BaseService, IRateService
    {
        public RateService(IHttpClientFactory factory) : base(factory)
        {
        }

        public async Task PostRateAsync(PostRate rate)
        {
            await PrivateClient.PostAsJsonAsync("rates", rate);
            await PrivateClient.GetAsync("recommendations/retrain");
        }

        public async Task PutRateAsync(Rate rate)
        {
            await PrivateClient.PutAsJsonAsync($"rates/{rate.Id}", rate);
            await PrivateClient.GetAsync("recommendations/retrain");
        }
    }
}
