using Newtonsoft.Json;

namespace EliteAPI.Events
{
    public class ApproachSettlementInfo : EventBase
    {
        [JsonProperty("Name")]
        public string Name { get; internal set; }

        [JsonProperty("Name_Localised")]
        public string NameLocalised { get; internal set; }

        [JsonProperty("BodyID")]
        public int BodyId { get; internal set; }

        [JsonProperty("BodyName")]
        public string BodyName { get; internal set; }

        [JsonProperty("SystemAddress")]
        public long SystemAddress { get; internal set; }

        [JsonProperty("MarketID")]
        public long MarketId { get; internal set; }

        [JsonProperty("Latitude")]
        public float Latitude { get; internal set; }

        [JsonProperty("Longitude")]
        public float Longitude { get; internal set; }

        internal static ApproachSettlementInfo Process(string json, EliteDangerousAPI api)
        {
            return api.Events.InvokeApproachSettlementEvent(JsonConvert.DeserializeObject<ApproachSettlementInfo>(json, JsonSettings.Settings));
        }
    }
}