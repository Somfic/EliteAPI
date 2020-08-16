using Newtonsoft.Json;

namespace EliteAPI.Event.Models
{
    public class PayBountiesEvent : EventBase
    {
        internal PayBountiesEvent() { }

        public static PayBountiesEvent FromJson(string json) => JsonConvert.DeserializeObject<PayBountiesEvent>(json);


        [JsonProperty("Amount")]
        public long Amount { get; internal set; }

        [JsonProperty("Faction")]
        public string Faction { get; internal set; }

        [JsonProperty("Faction_Localised")]
        public string FactionLocalised { get; internal set; }

        [JsonProperty("ShipID")]
        public long ShipId { get; internal set; }

        [JsonProperty("BrokerPercentage")]
        public float BrokerPercentage { get; internal set; }

        
    }
}