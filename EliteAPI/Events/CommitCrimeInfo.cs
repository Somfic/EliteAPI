using Newtonsoft.Json;

namespace EliteAPI.Events
{
    public class CommitCrimeInfo : EventBase
    {
        [JsonProperty("CrimeType")]
        public string CrimeType { get; internal set; }

        [JsonProperty("Faction")]
        public string Faction { get; internal set; }

        [JsonProperty("Victim")]
        public string Victim { get; internal set; }

        [JsonProperty("Victim_Localised")]
        public string VictimLocalised { get; internal set; }

        [JsonProperty("Bounty")]
        public long Bounty { get; internal set; }

        internal static CommitCrimeInfo Process(string json, EliteDangerousAPI api)
        {
            return api.Events.InvokeCommitCrimeEvent(JsonConvert.DeserializeObject<CommitCrimeInfo>(json, JsonSettings.Settings));
        }
    }
}