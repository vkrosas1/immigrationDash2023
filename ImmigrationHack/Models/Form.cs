using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Immigration_Dashboard_Server.Models
{
    public class Form
    {
        /// <summary>
        /// This id is the corresponding formId
        /// </summary>
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        [JsonProperty(PropertyName = "data")]
        public string Data { get; set; }

        [JsonProperty(PropertyName = "info")]
        public string Info { get; set; }

        [JsonProperty(PropertyName = "status")]
        public string Status { get; set; }

        [JsonProperty(PropertyName = "documenturi")]
        public string DocumentUrl { get; set; }

        [JsonProperty(PropertyName = "pathId")]
        public string PathId { get; set; }
    }
}