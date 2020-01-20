using Newtonsoft.Json;

namespace EliteAPI.Events
{
    public class StartJumpInfo : EventBase
    {
        [JsonProperty("JumpType")]
        public string JumpType { get; internal set; }

        [JsonProperty("StarSystem")]
        public string StarSystem { get; internal set; }

        [JsonProperty("SystemAddress")]
        public long SystemAddress { get; internal set; }

        [JsonProperty("StarClass")]
        public string StarClass { get; internal set; }

        internal static StartJumpInfo Process(string json, EliteDangerousAPI api)
        {
            return api.Events.InvokeStartJumpEvent(JsonConvert.DeserializeObject<StartJumpInfo>(json, JsonSettings.Settings));
        }
    }
}