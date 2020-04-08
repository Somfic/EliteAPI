using Newtonsoft.Json;

namespace EliteAPI.Events.Travel
{
    public class FSDJumpActiveState
    {
        internal FSDJumpActiveState() { }

        [JsonProperty("State")]
        public string State { get; internal set; }
    }
}