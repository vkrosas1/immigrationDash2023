using ImmigrationHack.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Immigration_Dashboard_Server.Models
{
    public class User
    {
        /// <summary>
        /// This id is the corresponding userId
        /// </summary>
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        [JsonProperty(PropertyName = "username")]
        public string UserName { get; set; }

        [JsonProperty(PropertyName = "password")]
        public string Password { get; set; }

        [JsonProperty(PropertyName = "usersettings")]
        public UserSettings UserSettings { get; set; }

        [JsonProperty(PropertyName = "email")]
        public UserSettings Email { get; set; }
    }
}