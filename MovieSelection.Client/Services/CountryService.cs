using System.Net.Http.Json;
using MovieSelection.Client.Interfaces;
using MovieSelection.Models.Entities;

namespace MovieSelection.Client.Services
{
    public class CountryService : BaseService, ICountryService
    {
        public CountryService(IHttpClientFactory factory) : base(factory)
        {
        }

        public async Task<IEnumerable<Country>> GetCountriesAsync()
        {
            var countries = await PublicClient.GetFromJsonAsync<IEnumerable<Country>>("countries");
            return countries;
        }
    }
}
