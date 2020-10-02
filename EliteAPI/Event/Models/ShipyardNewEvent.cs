using EliteAPI.Event.Models.Abstractions;
using Newtonsoft.Json;

namespace EliteAPI.Event.Models
{
    public class ShipyardNewEvent : EventBase
    {
        internal ShipyardNewEvent() { }

        public static ShipyardNewEvent FromJson(string json) => JsonConvert.DeserializeObject<ShipyardNewEvent>(json);


        [JsonProperty("ShipType")]
        public string ShipType { get; internal set; }

        [JsonProperty("ShipType_Localised")]
        public string ShipTypeLocalised { get; internal set; }

        [JsonProperty("NewShipID")]
        public long NewShipId { get; internal set; }

        
    }
}