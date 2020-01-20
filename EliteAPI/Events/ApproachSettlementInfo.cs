using Newtonsoft.Json;

namespace EliteAPI.Events
{
    public class ApproachSettlementInfo : EventBase
    {
        [JsonProperty("Name")]
        public string Name { get; internal set; }

        [JsonProperty("Name_Localised")]
        public string NameLocalised { get; internal set; }

        [JsonProperty("MarketID")]
        public long MarketId { get; internal set; }

        [JsonProperty("Latitude")]
        public double Latitude { get; internal set; }

        [JsonProperty("Longitude")]
        public double Longitude { get; internal set; }

        internal static ApproachSettlementInfo Process(string json, EliteDangerousAPI api)
        {
            return api.Events.InvokeApproachSettlementEvent(JsonConvert.DeserializeObject<ApproachSettlementInfo>(json, JsonSettings.Settings));
        }
    }
}