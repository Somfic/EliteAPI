namespace EliteAPI.Events
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public partial class AfmuRepairsInfo : IEvent
    {
        [JsonProperty("timestamp")]
        public DateTime Timestamp { get; internal set; }
        [JsonProperty("event")]
        public string Event { get; internal set; }
        /// <summary>
        /// The name of the module
        /// </summary>
        [JsonProperty("Module")]
        public string Module { get; internal set; }
        /// <summary>
        /// The local name of the module
        /// </summary>
        [JsonProperty("Module_Localised")]
        public string ModuleLocalised { get; internal set; }
        /// <summary>
        /// Whether modules are now fully repaired
        /// </summary>
        [JsonProperty("FullyRepaired")]
        public bool FullyRepaired { get; internal set; }
        /// <summary>
        /// Value between 0 and 1.
        /// </summary>
        [JsonProperty("Health")]
        public double Health { get; internal set; }
    }
    public partial class AfmuRepairsInfo
    {
        internal static AfmuRepairsInfo Process(string json, EliteDangerousAPI api) => api.Events.InvokeAfmuRepairsEvent(JsonConvert.DeserializeObject<AfmuRepairsInfo>(json, EliteAPI.Events.AfmuRepairsConverter.Settings));
    }    
    internal static class AfmuRepairsConverter
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
