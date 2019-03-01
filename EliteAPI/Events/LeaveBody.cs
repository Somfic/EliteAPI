namespace EliteAPI.Events
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public partial class LeaveBodyInfo
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
    }

    public partial class LeaveBodyInfo
    {
        public static LeaveBodyInfo Process(string json, EliteDangerousAPI api) => api.Events.InvokeLeaveBodyEvent(JsonConvert.DeserializeObject<LeaveBodyInfo>(json, EliteAPI.Events.LeaveBodyConverter.Settings));
    }

    public static class LeaveBodySerializer
    {
        public static string ToJson(this LeaveBodyInfo self) => JsonConvert.SerializeObject(self, EliteAPI.Events.LeaveBodyConverter.Settings);
    }

    internal static class LeaveBodyConverter
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
