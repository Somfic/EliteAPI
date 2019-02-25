namespace EliteAPI.Events
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public partial class MaterialsInfo
    {
        [JsonProperty("timestamp")]
        public DateTime Timestamp { get; set; }

        [JsonProperty("event")]
        public string Event { get; set; }

        [JsonProperty("Raw")]
        public List<Raw> Raw { get; set; }

        [JsonProperty("Manufactured")]
        public List<Encoded> Manufactured { get; set; }

        [JsonProperty("Encoded")]
        public List<Encoded> Encoded { get; set; }
    }

    public partial class Encoded
    {
        [JsonProperty("Name")]
        public string Name { get; set; }

        [JsonProperty("Name_Localised")]
        public string NameLocalised { get; set; }

        [JsonProperty("Count")]
        public long Count { get; set; }
    }

    public partial class Raw
    {
        [JsonProperty("Name")]
        public string Name { get; set; }

        [JsonProperty("Count")]
        public long Count { get; set; }
    }

    public partial class MaterialsInfo
    {
        public static MaterialsInfo Process(string json, EliteDangerousAPI api) => api.Events.InvokeMaterialsEvent(JsonConvert.DeserializeObject<MaterialsInfo>(json, EliteAPI.Events.MaterialsConverter.Settings));
    }

    public static class MaterialsSerializer
    {
        public static string ToJson(this MaterialsInfo self) => JsonConvert.SerializeObject(self, EliteAPI.Events.MaterialsConverter.Settings);
    }

    internal static class MaterialsConverter
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
