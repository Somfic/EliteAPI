namespace EliteAPI.Events
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public partial class MaterialCollectedInfo
    {
        [JsonProperty("timestamp")]
        public DateTime Timestamp { get; internal set; }

        [JsonProperty("event")]
        public string Event { get; internal set; }

        [JsonProperty("Category")]
        public string Category { get; internal set; }

        [JsonProperty("Name")]
        public string Name { get; internal set; }

        [JsonProperty("Name_Localised")]
        public string NameLocalised { get; internal set; }

        [JsonProperty("Count")]
        public long Count { get; internal set; }
    }

    public partial class MaterialCollectedInfo
    {
        public static MaterialCollectedInfo Process(string json, EliteDangerousAPI api) => api.Events.InvokeMaterialCollectedEvent(JsonConvert.DeserializeObject<MaterialCollectedInfo>(json, EliteAPI.Events.MaterialCollectedConverter.Settings));
    }

    public static class MaterialCollectedSerializer
    {
        public static string ToJson(this MaterialCollectedInfo self) => JsonConvert.SerializeObject(self, EliteAPI.Events.MaterialCollectedConverter.Settings);
    }

    internal static class MaterialCollectedConverter
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
