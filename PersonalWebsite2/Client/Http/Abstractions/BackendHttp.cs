namespace PersonalWebsite2.Client.Http.Abstractions
{
    public abstract class BackendHttp
    {
        public HttpClient _Client;
        public BackendHttp(IConfiguration configuration, IHttpClientFactory factory)
        {
            _Client = factory.CreateClient(configuration["BackendHttpClientName"] ?? "");
        }
    }
}