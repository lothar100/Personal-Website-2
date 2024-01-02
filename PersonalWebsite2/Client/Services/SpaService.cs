using PersonalWebsite2.Client.Http.Abstractions;
using PersonalWebsite2.Shared.Models;
using System.Net.Http.Json;

namespace PersonalWebsite2.Client.Services
{
    public class SpaService : BackendHttp
    {
        public static event Func<Task> OnUpdate;
        public string TargetId = "";
        public List<ModuleData> ServiceModules = new List<ModuleData>();

        public SpaService(IConfiguration configuration, IHttpClientFactory factory) : base(configuration, factory) { }

        public async Task<List<ModuleData>> GetAllAsync()
        {
            try
            {
                var response = await _Client.GetAsync("/GetAll");
                response.EnsureSuccessStatusCode();
                ServiceModules = await response.Content.ReadFromJsonAsync<List<ModuleData>>() ?? new List<ModuleData>();
                return ServiceModules;
            }
            finally
            {
                if (OnUpdate != null)
                    await OnUpdate.Invoke();
            }

        }

        public async Task PostEmailAsync(ContactEmailModel email)
        {
            var response = await _Client.PostAsJsonAsync("/ContactEmail", email);
            response.EnsureSuccessStatusCode();
        }

    }
}