using Newtonsoft.Json;

namespace EliteAPI.Events
{
    public class CrimeVictimInfo : EventBase
    {
        [JsonProperty("Offender")]
        public string Offender { get; internal set; }

        [JsonProperty("CrimeType")]
        public string CrimeType { get; internal set; }

        [JsonProperty("Bounty")]
        public long Bounty { get; internal set; }

        internal static CrimeVictimInfo Process(string json, EliteDangerousAPI api)
        {
            return api.Events.InvokeCrimeVictimEvent(JsonConvert.DeserializeObject<CrimeVictimInfo>(json, JsonSettings.Settings));
        }
    }
}