namespace EliteAPI.Events
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public partial class DatalinkVoucherInfo : IEvent
    {
        [JsonProperty("timestamp")]
        public DateTime Timestamp { get; internal set; }

        [JsonProperty("event")]
        public string Event { get; internal set; }

        [JsonProperty("Reward")]
        public long Reward { get; internal set; }

        [JsonProperty("VictimFaction")]
        public string VictimFaction { get; internal set; }

        [JsonProperty("PayeeFaction")]
        public string PayeeFaction { get; internal set; }
    }

    public partial class DatalinkVoucherInfo
    {
        public static DatalinkVoucherInfo Process(string json, EliteDangerousAPI api) => api.Events.InvokeDatalinkVoucherEvent(JsonConvert.DeserializeObject<DatalinkVoucherInfo>(json, EliteAPI.Events.DatalinkVoucherConverter.Settings));
    }

    public static class DatalinkVoucherSerializer
    {
        public static string ToJson(this DatalinkVoucherInfo self) => JsonConvert.SerializeObject(self, EliteAPI.Events.DatalinkVoucherConverter.Settings);
    }

    internal static class DatalinkVoucherConverter
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
