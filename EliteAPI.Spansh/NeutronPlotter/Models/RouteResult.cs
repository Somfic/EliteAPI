using Newtonsoft.Json;

namespace EliteAPI.Spansh.NeutronPlotter.Models
{
    internal class RouteResult
    {
        [JsonProperty("job")]
        public string Job { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }
        
        [JsonProperty("State")]
        public string State { get; set; }
    }
}