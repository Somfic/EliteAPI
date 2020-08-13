using Newtonsoft.Json;

namespace EliteAPI.Event.Models
{
    public class SetUserShipNameEvent : EventBase
    {
        internal SetUserShipNameEvent() { }
        [JsonProperty("Ship")]
        public string Ship { get; internal set; }

        [JsonProperty("ShipID")]
        public long ShipId { get; internal set; }

        [JsonProperty("UserShipName")]
        public string UserShipName { get; internal set; }

        [JsonProperty("UserShipId")]
        public string UserShipId { get; internal set; }

        
    }
}