namespace EliteAPI.Events
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    public partial class RepairDroneInfo : IEvent
    {
        [JsonProperty("timestamp")]
        public DateTime Timestamp { get; internal set; }
        [JsonProperty("event")]
        public string Event { get; internal set; }
        [JsonProperty("HullRepaired")]
        public double HullRepaired { get; internal set; }
        [JsonProperty("CockpitRepaired")]
        public double CockpitRepaired { get; internal set; }
    }
    public partial class RepairDroneInfo
    {
        internal static RepairDroneInfo Process(string json, EliteDangerousAPI api) => api.Events.InvokeRepairDroneEvent(JsonConvert.DeserializeObject<RepairDroneInfo>(json, EliteAPI.Events.RepairDroneConverter.Settings));
    }
    
    internal static class RepairDroneConverter
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
