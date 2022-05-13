using System.Net.Http.Json;
using MovieSelection.Client.Interfaces;
using MovieSelection.Models.RequestModels;

namespace MovieSelection.Client.Services
{
    public class UserService : BaseService, IUserService
    {
        public UserService(IHttpClientFactory factory) : base(factory)
        {
        }

        public async Task<IEnumerable<GetSaving>> GetSavingsAsync(Guid id)
        {
            var savings = await PrivateClient.GetFromJsonAsync<IEnumerable<GetSaving>>($"users/{id}/savings");
            return savings;
        }

        public async Task<IEnumerable<GetUserRate>> GetRatesAsync(Guid id)
        {
            var rates = await PrivateClient.GetFromJsonAsync<IEnumerable<GetUserRate>>($"users/{id}/rates");
            return rates;
        }
    }
}
