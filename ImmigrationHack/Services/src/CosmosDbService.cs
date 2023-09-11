using Immigration_Dashboard_Server.Services.Interfaces;
using Microsoft.Azure.Cosmos;
using Microsoft.VisualStudio.Web.CodeGeneration.Utils;

namespace Immigration_Dashboard_Server.Services
{
    public class CosmosDbService<T> : ICosmosDbService<T>
    {
        private Container _container;

        public CosmosDbService(
            CosmosClient dbClient,
            string databaseName,
            string containerName)
        {
            Requires.NotNull(dbClient, nameof(dbClient));
            Requires.NotNull(databaseName, nameof(databaseName));
            Requires.NotNull(containerName, nameof(containerName));

            this._container = dbClient.GetContainer(databaseName, containerName);
        }

        public async Task AddItemAsync(T item)
        {
            string key = (string)typeof(T).GetProperty("Id").GetValue(item);
            await this._container.CreateItemAsync<T>(item, new PartitionKey((string)typeof(T).GetProperty("Id").GetValue(item)));
        }

        public async Task DeleteItemAsync(string id)
        {
            await this._container.DeleteItemAsync<T>(id, new PartitionKey(id));
        }

        public async Task<T> GetItemAsync(string id)
        {
            try
            {
                ItemResponse<T> response = await this._container.ReadItemAsync<T>(id, new PartitionKey(id));
                return response.Resource;
            }
            catch (CosmosException ex) when (ex.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                return default(T);
            }
        }

        public async Task<List<T>> GetItemsAsync(string queryString)
        {
            var query = this._container.GetItemQueryIterator<T>(new QueryDefinition(queryString));
            List<T> results = new List<T>();
            while (query.HasMoreResults)
            {
                var response = await query.ReadNextAsync();

                results.AddRange(response.ToList());
            }
            return results;
        }

        public async Task UpdateItemAsync(string id, T item)
        {
            await this._container.UpsertItemAsync<T>(item, new PartitionKey(id));
        }
    }
}