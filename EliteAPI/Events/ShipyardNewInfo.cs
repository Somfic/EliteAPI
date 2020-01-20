using Newtonsoft.Json;

namespace EliteAPI.Events
{
    public class ShipyardNewInfo : EventBase
    {
        [JsonProperty("ShipType")]
        public string ShipType { get; internal set; }

        [JsonProperty("ShipType_Localised")]
        public string ShipTypeLocalised { get; internal set; }

        [JsonProperty("NewShipID")]
        public long NewShipId { get; internal set; }

        internal static ShipyardNewInfo Process(string json, EliteDangerousAPI api)
        {
            return api.Events.InvokeShipyardNewEvent(JsonConvert.DeserializeObject<ShipyardNewInfo>(json, JsonSettings.Settings));
        }
    }
}