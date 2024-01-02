using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DataModel;

namespace PersonalWebsite2.Shared.Context.Abstractions
{
    public abstract class DynamoDbContext<T> : DynamoDBContext where T : class
    {
        protected DynamoDbContext(IAmazonDynamoDB client) : base(client) { }
        protected virtual async Task<T> GetByIdAsync(string id) => await base.LoadAsync<T>(id);
        protected virtual async Task SaveAsync(T item) => await base.SaveAsync(item);
        protected virtual async Task DeleteByIdAsync(string id) => await base.DeleteAsync<T>(id);
        protected virtual async Task DeleteAsync(T item) => await base.DeleteAsync(item);
    }
}
