using Newtonsoft.Json;

namespace EliteAPI.Event.Models
{
    public class FSDActiveState
    {
        [JsonProperty("State")]
        public string State { get; internal set; }
    }
}