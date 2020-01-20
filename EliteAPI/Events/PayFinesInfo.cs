using Newtonsoft.Json;

namespace EliteAPI.Events
{
    public class PayFinesInfo : EventBase
    {
        [JsonProperty("Amount")]
        public long Amount { get; internal set; }

        [JsonProperty("AllFines")]
        public bool AllFines { get; internal set; }

        [JsonProperty("Faction")]
        public string Faction { get; internal set; }

        [JsonProperty("ShipID")]
        public long ShipId { get; internal set; }

        internal static PayFinesInfo Process(string json, EliteDangerousAPI api)
        {
            return api.Events.InvokePayFinesEvent(JsonConvert.DeserializeObject<PayFinesInfo>(json, JsonSettings.Settings));
        }
    }
}