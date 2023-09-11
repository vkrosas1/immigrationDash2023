using Immigration_Dashboard_Server.Models;
using Microsoft.Azure.Cosmos;

namespace Immigration_Dashboard_Server.Services
{
    public class DocumentsCosmosDbService : CosmosDbService<Document>
    {

        public DocumentsCosmosDbService(CosmosClient dbClient, string databaseName, string containerName) : base(dbClient, databaseName, containerName)
        {
        }
    }
}