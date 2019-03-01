namespace EliteAPI.Events
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public partial class PowerplayDefectInfo
    {
        [JsonProperty("timestamp")]
        public DateTime Timestamp { get; internal set; }

        [JsonProperty("event")]
        public string Event { get; internal set; }

        [JsonProperty("FromPower")]
        public string FromPower { get; internal set; }

        [JsonProperty("ToPower")]
        public string ToPower { get; internal set; }
    }

    public partial class PowerplayDefectInfo
    {
        public static PowerplayDefectInfo Process(string json, EliteDangerousAPI api) => api.Events.InvokePowerplayDefectEvent(JsonConvert.DeserializeObject<PowerplayDefectInfo>(json, EliteAPI.Events.PowerplayDefectConverter.Settings));
    }

    public static class PowerplayDefectSerializer
    {
        public static string ToJson(this PowerplayDefectInfo self) => JsonConvert.SerializeObject(self, EliteAPI.Events.PowerplayDefectConverter.Settings);
    }

    internal static class PowerplayDefectConverter
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
