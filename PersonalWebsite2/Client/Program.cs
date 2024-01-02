using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using PersonalWebsite2.Client;
using PersonalWebsite2.Client.Extensions;
using PersonalWebsite2.Client.Helpers;
using PersonalWebsite2.Client.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

// http clients
builder.Services.AddHttpClient();
builder.Services.AddHttpClient(builder.BackendClientName(), builder.ConfigureBackendClient());
builder.Services.AddScoped(sp => builder.BaseAddressHttpClient());

// services
builder.Services.AddScoped<SpaService>();
builder.Services.AddScoped<BrowserResizeHelper>();

await builder.Build().RunAsync();