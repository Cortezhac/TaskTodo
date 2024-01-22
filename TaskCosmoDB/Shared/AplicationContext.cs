using Microsoft.Azure.Cosmos;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
namespace TaskCosmoDB.Shared
{
    public class AplicationContext : DbContext
    {
        private readonly CosmosClient _cosmosClient;
        private readonly Database _database;
        public AplicationContext (CosmosClient cosmosClient, IConfiguration configuration)
        {
            _cosmosClient = cosmosClient;
            string databaseName = configuration.GetConnectionString("databaseName") ?? "Default";
            _database = _cosmosClient.CreateDatabaseIfNotExistsAsync(databaseName).Result;
        }

        public Container GetContainer<T>()
        {
            string modelName = GetModelName<T>();

            return _database.CreateContainerIfNotExistsAsync(modelName, "/id").Result;
        }
         
        private string GetModelName<T>()
        {
            return typeof(T).Name;
        }
    }
}
