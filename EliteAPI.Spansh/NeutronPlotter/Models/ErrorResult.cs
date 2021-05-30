using Newtonsoft.Json;

namespace EliteAPI.Spansh.NeutronPlotter.Models
{
    internal class ErrorResult
    {
        [JsonProperty("error")]
        public string Error { get; set; }
    }
}