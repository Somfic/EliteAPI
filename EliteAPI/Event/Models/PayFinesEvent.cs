using EliteAPI.Event.Models.Abstractions;
using Newtonsoft.Json;

namespace EliteAPI.Event.Models
{
    public class PayFinesEvent : EventBase
    {
        internal PayFinesEvent() { }

        public static PayFinesEvent FromJson(string json) => JsonConvert.DeserializeObject<PayFinesEvent>(json);


        [JsonProperty("Amount")]
        public long Amount { get; internal set; }

        [JsonProperty("AllFines")]
        public bool AllFines { get; internal set; }

        [JsonProperty("Faction")]
        public string Faction { get; internal set; }

        [JsonProperty("ShipID")]
        public long ShipId { get; internal set; }

        
    }
}