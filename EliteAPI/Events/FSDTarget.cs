namespace EliteAPI.Events
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    //{ "timestamp":"2019-10-15T17:50:50Z", "event":"FSDTarget", "Name":"Crucis Sector JC-V b2-5", "SystemAddress":11666607580601, "RemainingJumpsInRoute":2 }

    public partial class FSDTargetInfo : IEvent
    {
        [JsonProperty("timestamp")]
        public DateTime Timestamp { get; internal set; }

        [JsonProperty("event")]
        public string Event { get; internal set; }

        [JsonProperty("Name")]
        public string Name { get; internal set; }

        [JsonProperty("SystemAddress")]
        public long SystemAddress { get; internal set; }

        [JsonProperty("RemainingJumpsInRoute")]
        public int RemainingJumpsInRoute { get; internal set; }
    }

    public partial class FSDTargetInfo
    {
        public static FSDTargetInfo Process(string json, EliteDangerousAPI api) => api.Events.InvokeFSDTargetEvent(JsonConvert.DeserializeObject<FSDTargetInfo>(json, EliteAPI.Events.FSDTargetConverter.Settings));
    }

    

    internal static class FSDTargetConverter
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
