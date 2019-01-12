namespace EliteAPI.Events
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public partial class CodexEntryInfo
    {
        [JsonProperty("timestamp")]
        public DateTime Timestamp { get; set; }

        [JsonProperty("event")]
        public string Event { get; set; }

        [JsonProperty("EntryID")]
        public long EntryId { get; set; }

        [JsonProperty("Name")]
        public string Name { get; set; }

        [JsonProperty("Name_Localised")]
        public string NameLocalised { get; set; }

        [JsonProperty("SubCategory")]
        public string SubCategory { get; set; }

        [JsonProperty("SubCategory_Localised")]
        public string SubCategoryLocalised { get; set; }

        [JsonProperty("Category")]
        public string Category { get; set; }

        [JsonProperty("Category_Localised")]
        public string CategoryLocalised { get; set; }

        [JsonProperty("Region")]
        public string Region { get; set; }

        [JsonProperty("Region_Localised")]
        public string RegionLocalised { get; set; }

        [JsonProperty("System")]
        public string System { get; set; }

        [JsonProperty("SystemAddress")]
        public long SystemAddress { get; set; }

        [JsonProperty("IsNewEntry")]
        public bool IsNewEntry { get; set; }

        [JsonProperty("VoucherAmount")]
        public long VoucherAmount { get; set; }
    }

    public partial class CodexEntryInfo
    {
        public static CodexEntryInfo Process(string json, EliteDangerousAPI api) => api.Events.InvokeCodexEntryEvent(JsonConvert.DeserializeObject<CodexEntryInfo>(json, EliteAPI.Events.CodexEntryConverter.Settings));
    }

    public static class CodexEntrySerializer
    {
        public static string ToJson(this CodexEntryInfo self) => JsonConvert.SerializeObject(self, EliteAPI.Events.CodexEntryConverter.Settings);
    }

    internal static class CodexEntryConverter
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
