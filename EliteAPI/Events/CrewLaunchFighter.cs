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
        public DateTime Timestamp { get; set; }

        [JsonProperty("event")]
        public string Event { get; set; }

        [JsonProperty("Crew")]
        public string Crew { get; set; }
    }

    public partial class CrewLaunchFighterInfo
    {
        public static CrewLaunchFighterInfo Process(string json) => EventHandler.InvokeCrewLaunchFighterEvent(JsonConvert.DeserializeObject<CrewLaunchFighterInfo>(json, EliteAPI.Events.CrewLaunchFighterConverter.Settings));
    }

    public static class CrewLaunchFighterSerializer
    {
        public static string ToJson(this CrewLaunchFighterInfo self) => JsonConvert.SerializeObject(self, EliteAPI.Events.CrewLaunchFighterConverter.Settings);
    }

    internal static class CrewLaunchFighterConverter
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
