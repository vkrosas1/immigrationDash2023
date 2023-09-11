using Immigration_Dashboard_Server.Models;
using Immigration_Dashboard_Server.Services.Interfaces;
using Microsoft.Azure.Cosmos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using User = Immigration_Dashboard_Server.Models.User;

namespace Immigration_Dashboard_Server.Services
{
    public class UsersCosmosDbService : CosmosDbService<User>
    {
        public UsersCosmosDbService(CosmosClient dbClient, string databaseName, string containerName) : base(dbClient, databaseName, containerName)
        {
        }
    }
}