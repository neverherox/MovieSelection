using MovieSelection.Models.Entities;
using MovieSelection.Models.RequestModels;

namespace MovieSelection.Client.Interfaces
{
    public interface IRateService
    {
        Task PostRateAsync(PostRate rate);

        Task PutRateAsync(Rate rate);
    }
}
