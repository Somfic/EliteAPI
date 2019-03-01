namespace EliteAPI.Events
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public partial class CommanderInfo
    {
        [JsonProperty("timestamp")]
        public DateTime Timestamp { get; internal set; }

        [JsonProperty("event")]
        public string Event { get; internal set; }

        [JsonProperty("FID")]
        public string Fid { get; internal set; }

        [JsonProperty("Name")]
        public string Name { get; internal set; }
    }

    public partial class CommanderInfo
    {
        public static CommanderInfo Process(string json, EliteDangerousAPI api) => api.Events.InvokeCommanderEvent(JsonConvert.DeserializeObject<CommanderInfo>(json, EliteAPI.Events.CommanderConverter.Settings));
    }

    public static class CommanderSerializer
    {
        public static string ToJson(this CommanderInfo self) => JsonConvert.SerializeObject(self, EliteAPI.Events.CommanderConverter.Settings);
    }

    internal static class CommanderConverter
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
