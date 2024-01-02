using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DocumentModel;
using PersonalWebsite2.Shared.Context.Abstractions;
using PersonalWebsite2.Shared.Models;

namespace PersonalWebsite2.Shared.Context
{
    public class PageModuleContext : DynamoDbContext<ModuleData>
    {
        public PageModuleContext(IAmazonDynamoDB client) : base(client) { }

        public async Task<List<ModuleData>> GetAllAsync()
        {
            var scan = base.FromScanAsync<ModuleData>(
                new ScanOperationConfig { ConsistentRead = true }
            );
            var list = await scan.GetNextSetAsync();
            return list;
        }

    }
}
