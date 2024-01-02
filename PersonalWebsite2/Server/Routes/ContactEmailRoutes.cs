using Microsoft.AspNetCore.Mvc;
using PersonalWebsite2.Server.Services;
using PersonalWebsite2.Shared.Models;

namespace PersonalWebsite2.Server.Routes
{
    public class ContactEmailRoutes
    {
        public static async Task<IResult> PostEmailAsync([FromBody] ContactEmailModel email ,[FromServices] SnsService service)
        {
            await service.SendEmail(email);
            return Results.Ok();
        }
    }
}
