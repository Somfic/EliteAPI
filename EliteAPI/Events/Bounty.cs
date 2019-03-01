namespace EliteAPI.Events
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public partial class BountyInfo
    {
        [JsonProperty("timestamp")]
        public DateTime Timestamp { get; internal set; }

        [JsonProperty("event")]
        public string Event { get; internal set; }

        [JsonProperty("Rewards")]
        public List<Reward> Rewards { get; internal set; }

        [JsonProperty("Target")]
        public string Target { get; internal set; }

        [JsonProperty("TotalReward")]
        public long TotalReward { get; internal set; }

        [JsonProperty("VictimFaction")]
        public string VictimFaction { get; internal set; }

        [JsonProperty("SharedWithOthers")]
        public long SharedWithOthers { get; internal set; }
    }

    public partial class Reward
    {
        [JsonProperty("Faction")]
        public string Faction { get; internal set; }

        [JsonProperty("Reward")]
        public long RewardReward { get; internal set; }
    }

    public partial class BountyInfo
    {
        public static BountyInfo Process(string json, EliteDangerousAPI api) => api.Events.InvokeBountyEvent(JsonConvert.DeserializeObject<BountyInfo>(json, EliteAPI.Events.BountyConverter.Settings));
    }

    public static class BountySerializer    
    {
        public static string ToJson(this BountyInfo self) => JsonConvert.SerializeObject(self, EliteAPI.Events.BountyConverter.Settings);
    }

    internal static class BountyConverter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MissingMemberHandling = MissingMemberHandling.Ignore, MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters =
            {
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
        };
    }
}
