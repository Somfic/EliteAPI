using Newtonsoft.Json;

namespace EliteAPI.Events
{
    public class ActiveState
    {
        [JsonProperty("State")]
        public string State { get; internal set; }
    }
}