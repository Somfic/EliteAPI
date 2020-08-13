using Newtonsoft.Json;

namespace EliteAPI.Event.Models
{
    public class ShipyardNewEvent : EventBase
    {
        internal ShipyardNewEvent() { }
        [JsonProperty("ShipType")]
        public string ShipType { get; internal set; }

        [JsonProperty("ShipType_Localised")]
        public string ShipTypeLocalised { get; internal set; }

        [JsonProperty("NewShipID")]
        public long NewShipId { get; internal set; }

        
    }
}