using System.Net.Http.Json;
using MovieSelection.Client.Interfaces;
using MovieSelection.Models.Entities;

namespace MovieSelection.Client.Services
{
    public class RateService : BaseService, IRateService
    {
        public RateService(IHttpClientFactory factory) : base(factory)
        {
        }

        public async Task PostRateAsync(Rate rate)
        {
            await PrivateClient.PostAsJsonAsync("rates", rate);
        }

        public async Task PutRateAsync(Rate rate)
        {
            await PrivateClient.PutAsJsonAsync($"rates/{rate.Id}", rate);
        }
    }
}
