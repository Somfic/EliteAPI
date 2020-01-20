using System;

namespace EliteAPI.Events
{
    using System.Collections.Generic;
    using Newtonsoft.Json;

    public class PowerplayVoteInfo : EventBase
    {
        internal static PowerplayVoteInfo Process(string json, EliteDangerousAPI api) => api.Events.InvokePowerplayVoteEvent(JsonConvert.DeserializeObject<PowerplayVoteInfo>(json, JsonSettings.Settings));

        [JsonProperty("Power")]
        public string Power { get; internal set; }
        [JsonProperty("Votes")]
        public long Votes { get; internal set; }
        [JsonProperty("VoteToConsolidate")]
        public long VoteToConsolidate { get; internal set; }
    }
}
