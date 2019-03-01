namespace EliteAPI.Events
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public partial class MissionCompletedInfo
    {
        [JsonProperty("timestamp")]
        public DateTime Timestamp { get; internal set; }

        [JsonProperty("event")]
        public string Event { get; internal set; }

        [JsonProperty("Faction")]
        public string Faction { get; internal set; }

        [JsonProperty("Name")]
        public string Name { get; internal set; }

        [JsonProperty("MissionID")]
        public long MissionId { get; internal set; }

        [JsonProperty("TargetType")]
        public string TargetType { get; internal set; }

        [JsonProperty("TargetType_Localised")]
        public string TargetTypeLocalised { get; internal set; }

        [JsonProperty("TargetFaction")]
        public string TargetFaction { get; internal set; }

        [JsonProperty("NewDestinationSystem")]
        public string NewDestinationSystem { get; internal set; }

        [JsonProperty("DestinationSystem")]
        public string DestinationSystem { get; internal set; }

        [JsonProperty("NewDestinationStation")]
        public string NewDestinationStation { get; internal set; }

        [JsonProperty("DestinationStation")]
        public string DestinationStation { get; internal set; }

        [JsonProperty("Target")]
        public string Target { get; internal set; }

        [JsonProperty("Reward")]
        public long Reward { get; internal set; }

        [JsonProperty("MaterialsReward")]
        public List<MaterialsReward> MaterialsReward { get; internal set; }

        [JsonProperty("FactionEffects")]
        public List<FactionEffect> FactionEffects { get; internal set; }
    }

    public class FactionEffect
    {
        [JsonProperty("Faction")]
        public string Faction { get; internal set; }

        [JsonProperty("Effects")]
        public List<Effect> Effects { get; internal set; }

        [JsonProperty("Influence")]
        public List<Influence> Influence { get; internal set; }

        [JsonProperty("ReputationTrend")]
        public string ReputationTrend { get; internal set; }

        [JsonProperty("Reputation")]
        public string Reputation { get; internal set; }
    }

    public class Effect
    {
        [JsonProperty("Effect")]
        public string EffectEffect { get; internal set; }

        [JsonProperty("Effect_Localised")]
        public string EffectLocalised { get; internal set; }

        [JsonProperty("Trend")]
        public string Trend { get; internal set; }
    }

    public class Influence
    {
        [JsonProperty("SystemAddress")]
        public long SystemAddress { get; internal set; }

        [JsonProperty("Trend")]
        public string Trend { get; internal set; }

        [JsonProperty("Influence")]
        public string InfluenceInfluence { get; internal set; }
    }

    public class MaterialsReward
    {
        [JsonProperty("Name")]
        public string Name { get; internal set; }

        [JsonProperty("Name_Localised")]
        public string NameLocalised { get; internal set; }

        [JsonProperty("Category")]
        public string Category { get; internal set; }

        [JsonProperty("Category_Localised")]
        public string CategoryLocalised { get; internal set; }

        [JsonProperty("Count")]
        public long Count { get; internal set; }
    }

    public partial class MissionCompletedInfo
    {
        public static MissionCompletedInfo Process(string json, EliteDangerousAPI api) => api.Events.InvokeMissionCompletedEvent(JsonConvert.DeserializeObject<MissionCompletedInfo>(json, EliteAPI.Events.MissionCompletedConverter.Settings));
    }

    public static class MissionCompletedSerializer
    {
        public static string ToJson(this MissionCompletedInfo self) => JsonConvert.SerializeObject(self, EliteAPI.Events.MissionCompletedConverter.Settings);
    }

    internal static class MissionCompletedConverter
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
