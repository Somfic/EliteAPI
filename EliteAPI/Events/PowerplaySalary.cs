namespace EliteAPI.Events
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public partial class PowerplaySalaryInfo
    {
        [JsonProperty("timestamp")]
        public DateTime Timestamp { get; internal set; }

        [JsonProperty("event")]
        public string Event { get; internal set; }

        [JsonProperty("Power")]
        public string Power { get; internal set; }

        [JsonProperty("Amount")]
        public long Amount { get; internal set; }
    }

    public partial class PowerplaySalaryInfo
    {
        public static PowerplaySalaryInfo Process(string json, EliteDangerousAPI api) => api.Events.InvokePowerplaySalaryEvent(JsonConvert.DeserializeObject<PowerplaySalaryInfo>(json, EliteAPI.Events.PowerplaySalaryConverter.Settings));
    }

    public static class PowerplaySalarySerializer
    {
        public static string ToJson(this PowerplaySalaryInfo self) => JsonConvert.SerializeObject(self, EliteAPI.Events.PowerplaySalaryConverter.Settings);
    }

    internal static class PowerplaySalaryConverter
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
