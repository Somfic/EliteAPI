using Newtonsoft.Json;

namespace EliteAPI.Events
{
    public class PayBountiesInfo : EventBase
    {
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

        internal static PayBountiesInfo Process(string json, EliteDangerousAPI api)
        {
            return api.Events.InvokePayBountiesEvent(JsonConvert.DeserializeObject<PayBountiesInfo>(json, JsonSettings.Settings));
        }
    }
}