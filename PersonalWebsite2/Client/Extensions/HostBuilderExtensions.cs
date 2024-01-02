using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

namespace PersonalWebsite2.Client.Extensions
{
    public static class HostBuilderExtensions
    {
        public static string BackendClientName(this WebAssemblyHostBuilder builder)
        {
            string? backendHttpClientName = builder.Configuration["BackendHttpClientName"];

            if (backendHttpClientName == null)
                throw new ArgumentNullException(nameof(backendHttpClientName));

            return backendHttpClientName;
        }
        public static Action<HttpClient> ConfigureBackendClient(this WebAssemblyHostBuilder builder) =>
            client =>
            {
                string? backendAddress = builder.Configuration["BackendAddress"];

                if (backendAddress == null)
                    throw new ArgumentNullException(nameof(backendAddress));

                client.BaseAddress = new Uri(backendAddress);
            };

        public static HttpClient BaseAddressHttpClient(this WebAssemblyHostBuilder builder) =>
            new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) };
    }
}
