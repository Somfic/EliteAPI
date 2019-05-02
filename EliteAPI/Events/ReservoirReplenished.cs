namespace EliteAPI.Events
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public partial class ReservoirReplenishedInfo : IEvent
    {
        [JsonProperty("timestamp")]
        public DateTimeOffset Timestamp { get; set; }

        [JsonProperty("event")]
        public string Event { get; set; }

        [JsonProperty("FuelMain")]
        public double FuelMain { get; set; }

        [JsonProperty("FuelReservoir")]
        public double FuelReservoir { get; set; }
    }

    public partial class ReservoirReplenishedInfo
    {
        public static ReservoirReplenishedInfo Process(string json, EliteDangerousAPI api) => api.Events.InvokeReservoirReplenishedEvent(JsonConvert.DeserializeObject<ReservoirReplenishedInfo>(json, EliteAPI.Events.ReservoirReplenishedConverter.Settings));
    }

    public static class ReservoirReplenishedSerializer
    {
        public static string ToJson(this ReservoirReplenishedInfo self) => JsonConvert.SerializeObject(self, EliteAPI.Events.ReservoirReplenishedConverter.Settings);
    }

    internal static class ReservoirReplenishedConverter
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
