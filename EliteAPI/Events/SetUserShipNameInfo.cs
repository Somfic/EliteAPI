using Newtonsoft.Json;

namespace EliteAPI.Events
{
    public class SetUserShipNameInfo : EventBase
    {
        [JsonProperty("Ship")]
        public string Ship { get; internal set; }

        [JsonProperty("ShipID")]
        public long ShipId { get; internal set; }

        [JsonProperty("UserShipName")]
        public string UserShipName { get; internal set; }

        [JsonProperty("UserShipId")]
        public string UserShipId { get; internal set; }

        internal static SetUserShipNameInfo Process(string json, EliteDangerousAPI api)
        {
            return api.Events.InvokeSetUserShipNameEvent(JsonConvert.DeserializeObject<SetUserShipNameInfo>(json, JsonSettings.Settings));
        }
    }
}