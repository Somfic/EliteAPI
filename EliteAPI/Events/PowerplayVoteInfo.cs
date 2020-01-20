using Newtonsoft.Json;

namespace EliteAPI.Events
{
    public class PowerplayVoteInfo : EventBase
    {
        [JsonProperty("Power")]
        public string Power { get; internal set; }

        [JsonProperty("Votes")]
        public long Votes { get; internal set; }

        [JsonProperty("VoteToConsolidate")]
        public long VoteToConsolidate { get; internal set; }

        internal static PowerplayVoteInfo Process(string json, EliteDangerousAPI api)
        {
            return api.Events.InvokePowerplayVoteEvent(JsonConvert.DeserializeObject<PowerplayVoteInfo>(json, JsonSettings.Settings));
        }
    }
}