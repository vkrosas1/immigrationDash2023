using Microsoft.Azure.Cosmos;
using Path = Immigration_Dashboard_Server.Models.Path;

namespace Immigration_Dashboard_Server.Services
{
    public class PathsCosmosDbService : CosmosDbService<Path>
    {
        public PathsCosmosDbService(CosmosClient dbClient, string databaseName, string containerName) : base(dbClient, databaseName, containerName)
        {
        }
    }
}