using Microsoft.AspNetCore.Http;

namespace MovieSelection.Models.RequestModels
{
    public class PostMovie
    {
        public string Name { get; set; }

        public string? Description { get; set; }

        public int Year { get; set; }

        public int CountryId { get; set; }

        public string Image { get; set; }
    }
}
