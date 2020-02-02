using Newtonsoft.Json;

namespace EliteAPI.Events
{
    public class DatalinkScanInfo : EventBase
    {
        [JsonProperty("Message")]
        public string Message { get; internal set; }

        [JsonProperty("Message_Localised")]
        public string MessageLocalised { get; internal set; }

        internal static DatalinkScanInfo Process(string json, EliteDangerousAPI api)
        {
            return api.Events.InvokeDatalinkScanEvent(JsonConvert.DeserializeObject<DatalinkScanInfo>(json, JsonSettings.Settings));
        }
    }
}