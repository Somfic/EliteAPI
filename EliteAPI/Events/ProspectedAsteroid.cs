namespace EliteAPI.Events
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public partial class ProspectedAsteroidInfo
    {
        [JsonProperty("timestamp")]
        public DateTimeOffset Timestamp { get; set; }

        [JsonProperty("event")]
        public string Event { get; set; }

        [JsonProperty("Materials")]
        public List<ProspectedMaterial> Materials { get; set; }

        [JsonProperty("MotherlodeMaterial")]
        public string MotherlodeMaterial { get; set; }

        [JsonProperty("MotherlodeMaterial_Localised")]
        public string MotherlodeMaterialLocalised { get; set; }

        [JsonProperty("Content")]
        public string Content { get; set; }

        [JsonProperty("Content_Localised")]
        public string ContentLocalised { get; set; }

        [JsonProperty("Remaining")]
        public long Remaining { get; set; }
    }

    public partial class ProspectedMaterial
    {
        [JsonProperty("Name")]
        public string Name { get; set; }

        [JsonProperty("Name_Localised", NullValueHandling = NullValueHandling.Ignore)]
        public string NameLocalised { get; set; }

        [JsonProperty("Proportion")]
        public double Proportion { get; set; }
    }

    public partial class ProspectedAsteroidInfo
    {
        public static ProspectedAsteroidInfo Process(string json, EliteDangerousAPI api) => api.Events.InvokeProspectedAsteroidEvent(JsonConvert.DeserializeObject<ProspectedAsteroidInfo>(json, EliteAPI.Events.ProspectedAsteroidConverter.Settings));
    }

    public static class ProspectedAsteroidSerializer
    {
        public static string ToJson(this ProspectedAsteroidInfo self) => JsonConvert.SerializeObject(self, EliteAPI.Events.ProspectedAsteroidConverter.Settings);
    }

    internal static class ProspectedAsteroidConverter
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
