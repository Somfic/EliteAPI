using Newtonsoft.Json;

namespace EliteAPI.Events
{
    public class PayLegacyFinesInfo : EventBase
    {
        [JsonProperty("Amount")]
        public long Amount { get; internal set; }

        [JsonProperty("BrokerPercentage")]
        public float BrokerPercentage { get; internal set; }

        internal static PayLegacyFinesInfo Process(string json, EliteDangerousAPI api)
        {
            return api.Events.InvokePayLegacyFinesEvent(JsonConvert.DeserializeObject<PayLegacyFinesInfo>(json, JsonSettings.Settings));
        }
    }
}