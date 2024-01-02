using Amazon.Lambda.Core;
using Amazon.SimpleNotificationService;
using Amazon.SimpleNotificationService.Model;
using PersonalWebsite2.Shared.Models;

namespace PersonalWebsite2.Server.Services
{
    public class SnsService
    {
        private readonly IAmazonSimpleNotificationService _snsClient;
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly string _topicARN;
        public SnsService(
            IConfiguration configuration,
            IAmazonSimpleNotificationService snsClient,
            IHttpContextAccessor contextAccessor
        )
        {
            _snsClient = snsClient;
            _contextAccessor = contextAccessor;
            _topicARN = configuration["contact-email:arn"];
        }

        public async Task SendEmail(ContactEmailModel email)
        {
            try
            {
                string remoteIPAddress =
                    _contextAccessor.HttpContext?.Connection.RemoteIpAddress?.ToString() ?? "";

                string message =
                    $"From: {email.Name} | {email.EmailAddress} | {remoteIPAddress}\n" +
                    $"{email.Message}";

                var request = new PublishRequest(_topicARN, message, "PietrLangevoort.cloud Message");
                
                await _snsClient.PublishAsync(request);
            }
            catch (Exception ex)
            {
                LambdaLogger.Log($"{ex.Message}\n{ex.StackTrace}");
            }
        }
    }
}