using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Immigration_Dashboard_Server.Services
{
    public static class CosmosServiceConstants
    {
        public const string DatabaseName = "ImmigrationDashBoardDB";

        public const string UsersContainerName = "Users";

        public const string FormsContainerName = "Forms";

        public const string DocumentsContainerName = "Documents";

        public const string PathsContainerName = "Paths";

        public const string Account = "https://immigrationdashboarddb.documents.azure.com:443/";

        public const string PrimaryKey = "nKp2nr7JlftOzsmD7OLQweSaf7Hv5Qafvxe7JSAIvmmW6vbQHnrVGuuXKCMRl12aS16Rt2lQgQMFDqAVEdxDZg==";
    }
}