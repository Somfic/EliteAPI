using Newtonsoft.Json;

namespace EliteAPI.Events
{
    public class NavBeaconScanInfo : EventBase
    {
        [JsonProperty("SystemAddress")]
        public long SystemAddress { get; internal set; }

        [JsonProperty("NumBodies")]
        public long NumBodies { get; internal set; }

        internal static NavBeaconScanInfo Process(string json, EliteDangerousAPI api)
        {
            return api.Events.InvokeNavBeaconScanEvent(JsonConvert.DeserializeObject<NavBeaconScanInfo>(json, JsonSettings.Settings));
        }
    }
}