namespace MovieSelection.Api.Models
{
    public class PostActor
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public IFormFile Image { get; set; }
    }
}
