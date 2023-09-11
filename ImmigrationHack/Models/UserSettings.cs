using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Immigration_Dashboard_Server.Models
{
    public class UserSettings
    {
        [JsonProperty(PropertyName = "Visa")]
        public string Id { get; set; }

        [JsonProperty(PropertyName = "Progress")]
        public string Username { get; set; }
    }
}