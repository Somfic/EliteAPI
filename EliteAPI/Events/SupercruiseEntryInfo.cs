using Newtonsoft.Json;

namespace EliteAPI.Events
{
    public class SupercruiseEntryInfo : EventBase
    {
        [JsonProperty("StarSystem")]
        public string StarSystem { get; internal set; }

        [JsonProperty("SystemAddress")]
        public long SystemAddress { get; internal set; }

        internal static SupercruiseEntryInfo Process(string json, EliteDangerousAPI api)
        {
            return api.Events.InvokeSupercruiseEntryEvent(JsonConvert.DeserializeObject<SupercruiseEntryInfo>(json, JsonSettings.Settings));
        }
    }
}