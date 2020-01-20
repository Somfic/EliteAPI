using Newtonsoft.Json;

namespace EliteAPI.Events
{
    public class FSDActiveState
    {
        [JsonProperty("State")]
        public string State { get; internal set; }
    }
}