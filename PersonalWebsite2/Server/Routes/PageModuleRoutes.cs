using Amazon.Lambda.Core;
using Microsoft.AspNetCore.Mvc;
using PersonalWebsite2.Server.Services;

namespace PersonalWebsite2.Server.Routes
{
    public class PageModuleRoutes
    {
        public static async Task<IResult> PageModuleGetAllAsync([FromServices] ModuleService service)
        {
            var data = await service.GetAllAsync();
            return Results.Json(data);
        }

    }
}
