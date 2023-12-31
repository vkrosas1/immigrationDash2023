﻿using Immigration_Dashboard_Server.Models;
using Immigration_Dashboard_Server.Services.Interfaces;
using Microsoft.Azure.Cosmos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Immigration_Dashboard_Server.Services
{
    public class FormsCosmosDbService : CosmosDbService<Form>
    {
        public FormsCosmosDbService(CosmosClient dbClient, string databaseName, string containerName) : base(dbClient, databaseName, containerName)
        {
        }
    }
}