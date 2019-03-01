namespace EliteAPI.Events
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public partial class CrewLaunchFighterInfo
    {
        [JsonProperty("timestamp")]
        public DateTime Timestamp { get; internal set; }

        [JsonProperty("event")]
        public string Event { get; internal set; }

        [JsonProperty("Crew")]
        public string Crew { get; internal set; }
    }

    public partial class CrewLaunchFighterInfo
    {
        public static CrewLaunchFighterInfo Process(string json, EliteDangerousAPI api) => api.Events.InvokeCrewLaunchFighterEvent(JsonConvert.DeserializeObject<CrewLaunchFighterInfo>(json, EliteAPI.Events.CrewLaunchFighterConverter.Settings));
    }

    public static class CrewLaunchFighterSerializer
    {
        public static string ToJson(this CrewLaunchFighterInfo self) => JsonConvert.SerializeObject(self, EliteAPI.Events.CrewLaunchFighterConverter.Settings);
    }

    internal static class CrewLaunchFighterConverter
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
