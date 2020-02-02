using Newtonsoft.Json;

namespace EliteAPI.Events
{
    public class DataScannedInfo : EventBase
    {
        [JsonProperty("Type")]
        public string Type { get; internal set; }

        [JsonProperty("Type_Localised")]
        public string TypeLocalised { get; internal set; }

        internal static DataScannedInfo Process(string json, EliteDangerousAPI api)
        {
            return api.Events.InvokeDataScannedEvent(JsonConvert.DeserializeObject<DataScannedInfo>(json, JsonSettings.Settings));
        }
    }
}