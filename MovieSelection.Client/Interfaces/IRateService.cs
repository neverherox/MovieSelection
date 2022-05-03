using MovieSelection.Models.Entities;

namespace MovieSelection.Client.Interfaces
{
    public interface IRateService
    {
        Task PostRateAsync(Rate rate);

        Task PutRateAsync(Rate rate);
    }
}
