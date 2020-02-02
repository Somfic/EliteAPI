using Newtonsoft.Json;

namespace EliteAPI.Events
{
    public class PVPKillInfo : EventBase
    {
        [JsonProperty("Victim")]
        public string Victim { get; internal set; }

        [JsonProperty("CombatRank")]
        public long CombatRank { get; internal set; }

        internal static PVPKillInfo Process(string json, EliteDangerousAPI api)
        {
            return api.Events.InvokePVPKillEvent(JsonConvert.DeserializeObject<PVPKillInfo>(json, JsonSettings.Settings));
        }
    }
}