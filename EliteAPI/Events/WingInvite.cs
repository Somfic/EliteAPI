namespace EliteAPI.Events
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public partial class WingInviteInfo
    {
        [JsonProperty("timestamp")]
        public DateTime Timestamp { get; set; }

        [JsonProperty("event")]
        public string Event { get; set; }

        [JsonProperty("Name")]
        public string Name { get; set; }
    }

    public partial class WingInviteInfo
    {
        public static WingInviteInfo Process(string json) => EventHandler.InvokeWingInviteEvent(JsonConvert.DeserializeObject<WingInviteInfo>(json, EliteAPI.Events.WingInviteConverter.Settings));
    }

    public static class WingInviteSerializer
    {
        public static string ToJson(this WingInviteInfo self) => JsonConvert.SerializeObject(self, EliteAPI.Events.WingInviteConverter.Settings);
    }

    internal static class WingInviteConverter
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
