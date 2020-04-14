using Newtonsoft.Json;

namespace EliteAPI.Events
{
    public class SAAScanCompleteInfo : EventBase
    {
        [JsonProperty("SystemAddress")]
        public long SystemAddress { get; internal set; }

        [JsonProperty("BodyName")]
        public string BodyName { get; internal set; }

        [JsonProperty("BodyID")]
        public long BodyId { get; internal set; }

        [JsonProperty("ProbesUsed")]
        public long ProbesUsed { get; internal set; }

        [JsonProperty("EfficiencyTarget")]
        public long EfficiencyTarget { get; internal set; }

        internal static SAAScanCompleteInfo Process(string json, EliteDangerousAPI api)
        {
            return api.Events.InvokeSAAScanCompleteEvent(JsonConvert.DeserializeObject<SAAScanCompleteInfo>(json, JsonSettings.Settings));
        }
    }
}