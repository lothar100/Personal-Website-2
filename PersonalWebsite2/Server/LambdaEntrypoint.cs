namespace PersonalWebsite2.Server
{
    public class LambdaEntryPoint : Amazon.Lambda.AspNetCoreServer.APIGatewayHttpApiV2ProxyFunction
    {
        protected override void Init(IWebHostBuilder builder) { builder.UseStartup<Program>(); }
        protected override void Init(IHostBuilder builder) { }
    }
}
