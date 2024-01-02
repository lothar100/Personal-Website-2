using Amazon.Lambda.Core;
using PersonalWebsite2.Shared.Context;
using PersonalWebsite2.Shared.Models;

namespace PersonalWebsite2.Server.Services
{
    public class ModuleService
    {
        private readonly PageModuleContext _context;
        public ModuleService(PageModuleContext context)
        {
            _context = context;
        }

        public async Task<List<ModuleData>> GetAllAsync()
        {
            try
            {
                var pageModules =
                    (await _context.GetAllAsync())
                    .Where(x => x.active)
                    .OrderBy(x => x.sortOrder)
                    .ToList();

                return pageModules;
            }
            catch (Exception ex)
            {
                LambdaLogger.Log($"{ex.Message}\n{ex.StackTrace}");
                return new List<ModuleData>();
            }
        }
    }
}
