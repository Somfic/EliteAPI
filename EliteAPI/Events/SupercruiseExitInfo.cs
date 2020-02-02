using Newtonsoft.Json;

namespace EliteAPI.Events
{
    public class SupercruiseExitInfo : EventBase
    {
        [JsonProperty("StarSystem")]
        public string StarSystem { get; internal set; }

        [JsonProperty("SystemAddress")]
        public long SystemAddress { get; internal set; }

        [JsonProperty("Body")]
        public string Body { get; internal set; }

        [JsonProperty("BodyID")]
        public long BodyId { get; internal set; }

        [JsonProperty("BodyType")]
        public string BodyType { get; internal set; }

        internal static SupercruiseExitInfo Process(string json, EliteDangerousAPI api)
        {
            return api.Events.InvokeSupercruiseExitEvent(JsonConvert.DeserializeObject<SupercruiseExitInfo>(json, JsonSettings.Settings));
        }
    }
}