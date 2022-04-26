using Microsoft.AspNetCore.Http;

namespace MovieSelection.Models.RequestModels
{
    public class PostActor
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public IFormFile Image { get; set; }
    }
}
