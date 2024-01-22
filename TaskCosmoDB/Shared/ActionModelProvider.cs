using Microsoft.Azure.Cosmos;
using System.ComponentModel;

namespace TaskCosmoDB.Shared
{
    public class ActionModelProvider<T>
    {
        public async Task<List<T>> All(AplicationContext cosmosDbContext)
        {
            var query = new QueryDefinition("SELECT * FROM c");
            var container = cosmosDbContext.GetContainer<T>();
            var iterator = container.GetItemQueryIterator<T>(query);

            var list = new List<T>();
            while (iterator.HasMoreResults)
            {
                var response = await iterator.ReadNextAsync();
                list.AddRange(response.ToList());
            }

            return list;
        }

        public async Task Create(AplicationContext cosmosDbContext, T item)
        {
            var container = cosmosDbContext.GetContainer<T>();
            await container.CreateItemAsync(item);
        }
         
        public async Task Delete(AplicationContext cosmosDbContext, string itemId)
        {
            var container = cosmosDbContext.GetContainer<T>();
            await container.DeleteItemAsync<T>(itemId, new PartitionKey(itemId));
        }

        public async Task Update(AplicationContext cosmosDbContext, string itemId, T updatedItem)
        {
            var container = cosmosDbContext.GetContainer<T>();
            await container.ReplaceItemAsync(updatedItem, itemId, new PartitionKey(itemId));
        }
    }
}
