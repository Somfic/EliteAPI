namespace EliteAPI.Events
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public partial class MissionsInfo
    {
        [JsonProperty("timestamp")]
        public DateTime Timestamp { get; internal set; }

        [JsonProperty("event")]
        public string Event { get; internal set; }

        [JsonProperty("Active")]
        public List<Active> Active { get; internal set; }

        [JsonProperty("Failed")]
        public List<object> Failed { get; internal set; }

        [JsonProperty("Complete")]
        public List<object> Complete { get; internal set; }
    }

    public partial class Active
    {
        [JsonProperty("MissionID")]
        public long MissionId { get; internal set; }

        [JsonProperty("Name")]
        public string Name { get; internal set; }

        [JsonProperty("PassengerMission")]
        public bool PassengerMission { get; internal set; }

        [JsonProperty("Expires")]
        public long Expires { get; internal set; }
    }

    public partial class MissionsInfo
    {
        public static MissionsInfo Process(string json, EliteDangerousAPI api) => api.Events.InvokeMissionsEvent(JsonConvert.DeserializeObject<MissionsInfo>(json, EliteAPI.Events.MissionsConverter.Settings));
    }

    public static class MissionsSerializer
    {
        public static string ToJson(this MissionsInfo self) => JsonConvert.SerializeObject(self, EliteAPI.Events.MissionsConverter.Settings);
    }

    internal static class MissionsConverter
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
