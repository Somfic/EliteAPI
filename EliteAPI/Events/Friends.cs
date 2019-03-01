namespace EliteAPI.Events
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public partial class FriendsInfo
    {
        [JsonProperty("timestamp")]
        public DateTime Timestamp { get; internal set; }

        [JsonProperty("event")]
        public string Event { get; internal set; }

        [JsonProperty("Status")]
        public string Status { get; internal set; }

        [JsonProperty("Name")]
        public string Name { get; internal set; }
    }

    public partial class FriendsInfo
    {
        public static FriendsInfo Process(string json, EliteDangerousAPI api) => api.Events.InvokeFriendsEvent(JsonConvert.DeserializeObject<FriendsInfo>(json, EliteAPI.Events.FriendsConverter.Settings));
    }

    public static class FriendsSerializer
    {
        public static string ToJson(this FriendsInfo self) => JsonConvert.SerializeObject(self, EliteAPI.Events.FriendsConverter.Settings);
    }

    internal static class FriendsConverter
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
