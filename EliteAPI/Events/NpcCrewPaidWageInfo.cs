using Newtonsoft.Json;

namespace EliteAPI.Events
{
    public class NpcCrewPaidWageInfo : EventBase
    {
        [JsonProperty("NpcCrewName")]
        public string NpcCrewName { get; internal set; }

        [JsonProperty("NpcCrewId")]
        public long NpcCrewId { get; internal set; }

        [JsonProperty("Amount")]
        public long Amount { get; internal set; }

        internal static NpcCrewPaidWageInfo Process(string json, EliteDangerousAPI api)
        {
            return api.Events.InvokeNpcCrewPaidWageEvent(JsonConvert.DeserializeObject<NpcCrewPaidWageInfo>(json, JsonSettings.Settings));
        }
    }
}