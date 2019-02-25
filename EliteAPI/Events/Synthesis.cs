namespace EliteAPI.Events
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public partial class SynthesisInfo
    {
        [JsonProperty("timestamp")]
        public DateTime Timestamp { get; set; }

        [JsonProperty("event")]
        public string Event { get; set; }

        [JsonProperty("Name")]
        public string Name { get; set; }

        [JsonProperty("Materials")]
        public List<SynthesisMaterial> Materials { get; set; }
    }

    public partial class SynthesisMaterial
    {
        [JsonProperty("Name")]
        public string Name { get; set; }

        [JsonProperty("Name_Localised", NullValueHandling = NullValueHandling.Ignore)]
        public string NameLocalised { get; set; }

        [JsonProperty("Count")]
        public long Count { get; set; }
    }

    public partial class SynthesisInfo
    {
        public static SynthesisInfo Process(string json, EliteDangerousAPI api) => api.Events.InvokeSynthesisEvent(JsonConvert.DeserializeObject<SynthesisInfo>(json, EliteAPI.Events.SynthesisConverter.Settings));
    }

    public static class SynthesisSerializer
    {
        public static string ToJson(this SynthesisInfo self) => JsonConvert.SerializeObject(self, EliteAPI.Events.SynthesisConverter.Settings);
    }

    internal static class SynthesisConverter
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
