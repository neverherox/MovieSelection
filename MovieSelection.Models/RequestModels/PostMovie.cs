using Microsoft.AspNetCore.Http;

namespace MovieSelection.Models.RequestModels
{
    public class PostMovie
    {
        public string Name { get; set; }

        public string? Description { get; set; }

        public short Year { get; set; }

        public int CountryId { get; set; }

        public IFormFile Image { get; set; }
    }
}
