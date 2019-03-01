namespace EliteAPI.Events
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public partial class SupercruiseExitInfo
    {
        [JsonProperty("timestamp")]
        public DateTime Timestamp { get; internal set; }

        [JsonProperty("event")]
        public string Event { get; internal set; }

        [JsonProperty("StarSystem")]
        public string StarSystem { get; internal set; }

        [JsonProperty("SystemAddress")]
        public long SystemAddress { get; internal set; }

        [JsonProperty("Body")]
        public string Body { get; internal set; }

        [JsonProperty("BodyID")]
        public long BodyId { get; internal set; }

        [JsonProperty("BodyType")]
        public string BodyType { get; internal set; }
    }

    public partial class SupercruiseExitInfo
    {
        public static SupercruiseExitInfo Process(string json, EliteDangerousAPI api) => api.Events.InvokeSupercruiseExitEvent(JsonConvert.DeserializeObject<SupercruiseExitInfo>(json, EliteAPI.Events.SupercruiseExitConverter.Settings));
    }

    public static class SupercruiseExitSerializer
    {
        public static string ToJson(this SupercruiseExitInfo self) => JsonConvert.SerializeObject(self, EliteAPI.Events.SupercruiseExitConverter.Settings);
    }

    internal static class SupercruiseExitConverter
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
