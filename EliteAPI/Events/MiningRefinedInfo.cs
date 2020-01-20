using Newtonsoft.Json;

namespace EliteAPI.Events
{
    public class MiningRefinedInfo : EventBase
    {
        [JsonProperty("Type")]
        public string Type { get; internal set; }

        [JsonProperty("Type_Localised")]
        public string TypeLocalised { get; internal set; }

        internal static MiningRefinedInfo Process(string json, EliteDangerousAPI api)
        {
            return api.Events.InvokeMiningRefinedEvent(JsonConvert.DeserializeObject<MiningRefinedInfo>(json, JsonSettings.Settings));
        }
    }
}