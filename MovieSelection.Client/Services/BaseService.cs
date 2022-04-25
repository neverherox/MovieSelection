namespace MovieSelection.Client.Services
{
    public abstract class BaseService
    {
        protected readonly HttpClient PrivateClient;
        protected readonly HttpClient PublicClient;

        protected BaseService(IHttpClientFactory factory)
        {
            PrivateClient = factory.CreateClient("api");
            PublicClient = factory.CreateClient("public");
        }
    }
}
