using Newtonsoft.Json;

namespace EliteAPI.Event.Models
{
    public class FSDJumpFactionState
    {
        [JsonProperty("State")]
        public string State { get; internal set; }

        [JsonProperty("Trend")]
        public long Trend { get; internal set; }
    }
}