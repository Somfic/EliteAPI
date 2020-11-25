using Newtonsoft.Json;

namespace EliteAPI.Event.Models.Travel
{
    public class FSDJumpActiveState
    {
        internal FSDJumpActiveState() { }

        [JsonProperty("State")]
        public string State { get; internal set; }
    }
}