using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Immigration_Dashboard_Server.Models
{
    public class Path
    {
        /// <summary>
        /// This id is the corresponding pathId
        /// </summary>
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        [JsonProperty(PropertyName = "pathForms")]
        public List<string> PathForms { get; set; }
    }
}