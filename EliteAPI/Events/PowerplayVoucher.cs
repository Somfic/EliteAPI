namespace EliteAPI.Events
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public partial class PowerplayVoucherInfo
    {
        [JsonProperty("timestamp")]
        public DateTime Timestamp { get; internal set; }

        [JsonProperty("event")]
        public string Event { get; internal set; }

        [JsonProperty("Power")]
        public string Power { get; internal set; }

        [JsonProperty("Systems")]
        public List<string> Systems { get; internal set; }
    }

    public partial class PowerplayVoucherInfo
    {
        public static PowerplayVoucherInfo Process(string json, EliteDangerousAPI api) => api.Events.InvokePowerplayVoucherEvent(JsonConvert.DeserializeObject<PowerplayVoucherInfo>(json, EliteAPI.Events.PowerplayVoucherConverter.Settings));
    }

    public static class PowerplayVoucherSerializer
    {
        public static string ToJson(this PowerplayVoucherInfo self) => JsonConvert.SerializeObject(self, EliteAPI.Events.PowerplayVoucherConverter.Settings);
    }

    internal static class PowerplayVoucherConverter
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
