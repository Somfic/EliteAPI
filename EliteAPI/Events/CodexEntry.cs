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
        public DateTime Timestamp { get; internal set; }

        [JsonProperty("event")]
        public string Event { get; internal set; }

        [JsonProperty("EntryID")]
        public long EntryId { get; internal set; }

        [JsonProperty("Name")]
        public string Name { get; internal set; }

        [JsonProperty("Name_Localised")]
        public string NameLocalised { get; internal set; }

        [JsonProperty("SubCategory")]
        public string SubCategory { get; internal set; }

        [JsonProperty("SubCategory_Localised")]
        public string SubCategoryLocalised { get; internal set; }

        [JsonProperty("Category")]
        public string Category { get; internal set; }

        [JsonProperty("Category_Localised")]
        public string CategoryLocalised { get; internal set; }

        [JsonProperty("Region")]
        public string Region { get; internal set; }

        [JsonProperty("Region_Localised")]
        public string RegionLocalised { get; internal set; }

        [JsonProperty("System")]
        public string System { get; internal set; }

        [JsonProperty("SystemAddress")]
        public long SystemAddress { get; internal set; }

        [JsonProperty("IsNewEntry")]
        public bool IsNewEntry { get; internal set; }

        [JsonProperty("VoucherAmount")]
        public long VoucherAmount { get; internal set; }
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
            MissingMemberHandling = MissingMemberHandling.Ignore, MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters =
            {
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
        };
    }
}
