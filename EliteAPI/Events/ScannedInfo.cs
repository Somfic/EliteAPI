using Newtonsoft.Json;

namespace EliteAPI.Events
{
    public class ScannedInfo : EventBase
    {
        [JsonProperty("ScanType")]
        public string ScanType { get; internal set; }

        internal static ScannedInfo Process(string json, EliteDangerousAPI api)
        {
            return api.Events.InvokeScannedEvent(JsonConvert.DeserializeObject<ScannedInfo>(json, JsonSettings.Settings));
        }
    }
}