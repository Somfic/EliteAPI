namespace EliteAPI.Events
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    public partial class BuyExplorationDataInfo : IEvent
    {
        [JsonProperty("timestamp")]
        public DateTime Timestamp { get; internal set; }
        [JsonProperty("event")]
        public string Event { get; internal set; }
        [JsonProperty("System")]
        public string System { get; internal set; }
        [JsonProperty("Cost")]
        public long Cost { get; internal set; }
    }
    public partial class BuyExplorationDataInfo
    {
        internal static BuyExplorationDataInfo Process(string json, EliteDangerousAPI api) => api.Events.InvokeBuyExplorationDataEvent(JsonConvert.DeserializeObject<BuyExplorationDataInfo>(json, EliteAPI.Events.BuyExplorationDataConverter.Settings));
    }
    
    internal static class BuyExplorationDataConverter
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
