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
        public DateTime Timestamp { get; set; }

        [JsonProperty("event")]
        public string Event { get; set; }

        [JsonProperty("Faction")]
        public string Faction { get; set; }

        [JsonProperty("Name")]
        public string Name { get; set; }

        [JsonProperty("MissionID")]
        public long MissionId { get; set; }

        [JsonProperty("TargetType")]
        public string TargetType { get; set; }

        [JsonProperty("TargetType_Localised")]
        public string TargetTypeLocalised { get; set; }

        [JsonProperty("TargetFaction")]
        public string TargetFaction { get; set; }

        [JsonProperty("NewDestinationSystem")]
        public string NewDestinationSystem { get; set; }

        [JsonProperty("DestinationSystem")]
        public string DestinationSystem { get; set; }

        [JsonProperty("NewDestinationStation")]
        public string NewDestinationStation { get; set; }

        [JsonProperty("DestinationStation")]
        public string DestinationStation { get; set; }

        [JsonProperty("Target")]
        public string Target { get; set; }

        [JsonProperty("Reward")]
        public long Reward { get; set; }

        [JsonProperty("MaterialsReward")]
        public List<MaterialsReward> MaterialsReward { get; set; }

        [JsonProperty("FactionEffects")]
        public List<FactionEffect> FactionEffects { get; set; }
    }

    public partial class FactionEffect
    {
        [JsonProperty("Faction")]
        public string Faction { get; set; }

        [JsonProperty("Effects")]
        public List<Effect> Effects { get; set; }

        [JsonProperty("Influence")]
        public List<Influence> Influence { get; set; }

        [JsonProperty("ReputationTrend")]
        public string ReputationTrend { get; set; }

        [JsonProperty("Reputation")]
        public string Reputation { get; set; }
    }

    public partial class Effect
    {
        [JsonProperty("Effect")]
        public string EffectEffect { get; set; }

        [JsonProperty("Effect_Localised")]
        public string EffectLocalised { get; set; }

        [JsonProperty("Trend")]
        public string Trend { get; set; }
    }

    public partial class Influence
    {
        [JsonProperty("SystemAddress")]
        public long SystemAddress { get; set; }

        [JsonProperty("Trend")]
        public string Trend { get; set; }

        [JsonProperty("Influence")]
        public string InfluenceInfluence { get; set; }
    }

    public partial class MaterialsReward
    {
        [JsonProperty("Name")]
        public string Name { get; set; }

        [JsonProperty("Name_Localised")]
        public string NameLocalised { get; set; }

        [JsonProperty("Category")]
        public string Category { get; set; }

        [JsonProperty("Category_Localised")]
        public string CategoryLocalised { get; set; }

        [JsonProperty("Count")]
        public long Count { get; set; }
    }

    public partial class MissionCompletedInfo
    {
        public static MissionCompletedInfo Process(string json, EliteDangerousAPI api) => api.EventHandler.InvokeMissionCompletedEvent(JsonConvert.DeserializeObject<MissionCompletedInfo>(json, EliteAPI.Events.MissionCompletedConverter.Settings));
    }

    public static class MissionCompletedSerializer
    {
        public static string ToJson(this MissionCompletedInfo self) => JsonConvert.SerializeObject(self, EliteAPI.Events.MissionCompletedConverter.Settings);
    }

    internal static class MissionCompletedConverter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters =
            {
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
        };
    }
}
