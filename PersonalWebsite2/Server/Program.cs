using Amazon;
using Amazon.DynamoDBv2;
using Amazon.Extensions.NETCore.Setup;
using Amazon.SimpleNotificationService;
using PersonalWebsite2.Server.Routes;
using PersonalWebsite2.Server.Services;
using PersonalWebsite2.Shared.Context;

var builder = WebApplication.CreateBuilder(args);

// hosting
builder.Services.AddRazorPages();
builder.Services.AddAWSLambdaHosting(LambdaEventSource.HttpApi);
builder.Services.AddCors();

// configuration
builder.Configuration.AddSystemsManager(builder.Configuration["AWS:ConfigPath"]);

// aws services
builder.Services.AddAWSService<IAmazonDynamoDB>();
builder.Services.AddAWSService<IAmazonSimpleNotificationService>();

// msft services
builder.Services.AddHttpContextAccessor();

// services
builder.Services.AddScoped<ModuleService>();
builder.Services.AddScoped<SnsService>();

// contexts
builder.Services.AddSingleton<PageModuleContext>();

var app = builder.Build();

app.UseCors(options =>
    options
    .AllowAnyMethod()
    .AllowAnyHeader()
    .SetIsOriginAllowed(origin => true) // allow any origin
    .AllowCredentials()
);

app.MapGet("/GetAll", PageModuleRoutes.PageModuleGetAllAsync);
app.MapPost("/ContactEmail", ContactEmailRoutes.PostEmailAsync);

app.UseExceptionHandler("/Error");

app.UseHttpsRedirection();

app.UseBlazorFrameworkFiles();
app.UseStaticFiles();

app.UseRouting();


app.MapRazorPages();
app.MapFallbackToFile("index.html");

app.Run();