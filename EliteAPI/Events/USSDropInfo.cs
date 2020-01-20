using Newtonsoft.Json;

namespace EliteAPI.Events
{
    public class USSDropInfo : EventBase
    {
        [JsonProperty("USSType")]
        public string UssType { get; internal set; }

        [JsonProperty("USSType_Localised")]
        public string UssTypeLocalised { get; internal set; }

        [JsonProperty("USSThreat")]
        public long UssThreat { get; internal set; }

        internal static USSDropInfo Process(string json, EliteDangerousAPI api)
        {
            return api.Events.InvokeUSSDropEvent(JsonConvert.DeserializeObject<USSDropInfo>(json, JsonSettings.Settings));
        }
    }
}