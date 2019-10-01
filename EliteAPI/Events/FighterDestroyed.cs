namespace EliteAPI.Events
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public partial class FighterDestroyedInfo : IEvent
    {
        [JsonProperty("timestamp")]
        public DateTime Timestamp { get; internal set; }

        [JsonProperty("event")]
        public string Event { get; internal set; }
    }

    public partial class FighterDestroyedInfo
    {
        public static FighterDestroyedInfo Process(string json, EliteDangerousAPI api) => api.Events.InvokeFighterDestroyedEvent(JsonConvert.DeserializeObject<FighterDestroyedInfo>(json, EliteAPI.Events.FighterDestroyedConverter.Settings));
    }

    

    internal static class FighterDestroyedConverter
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
