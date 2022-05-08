using MovieSelection.Models.Entities;

namespace MovieSelection.Client.Interfaces
{
    public interface ICountryService
    {
        Task<IEnumerable<Country>> GetCountriesAsync();
    }
}
