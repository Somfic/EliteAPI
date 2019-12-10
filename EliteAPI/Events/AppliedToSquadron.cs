namespace EliteAPI.Events
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    public partial class AppliedToSquadronInfo : IEvent
    {
        [JsonProperty("timestamp")]
        public DateTime Timestamp { get; internal set; }
        [JsonProperty("event")]
        public string Event { get; internal set; }
        [JsonProperty("SquadronName")]
        public string SquadronName { get; internal set; }
    }
    public partial class AppliedToSquadronInfo
    {
        internal static AppliedToSquadronInfo Process(string json, EliteDangerousAPI api) => api.Events.InvokeAppliedToSquadronEvent(JsonConvert.DeserializeObject<AppliedToSquadronInfo>(json, EliteAPI.Events.AppliedToSquadronConverter.Settings));
    }
    
    internal static class AppliedToSquadronConverter
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
