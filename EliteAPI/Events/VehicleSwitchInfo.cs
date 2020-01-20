using Newtonsoft.Json;

namespace EliteAPI.Events
{
    public class VehicleSwitchInfo : EventBase
    {
        [JsonProperty("To")]
        public string To { get; internal set; }

        internal static VehicleSwitchInfo Process(string json, EliteDangerousAPI api)
        {
            return api.Events.InvokeVehicleSwitchEvent(JsonConvert.DeserializeObject<VehicleSwitchInfo>(json, JsonSettings.Settings));
        }
    }
}