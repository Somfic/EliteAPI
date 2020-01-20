using System;

namespace EliteAPI.Events
{
    using System.Collections.Generic;
    using Newtonsoft.Json;

    public class ReceiveTextInfo : IEvent
    {
        internal static ReceiveTextInfo Process(string json, EliteDangerousAPI api) => api.Events.InvokeReceiveTextEvent(JsonConvert.DeserializeObject<ReceiveTextInfo>(json, JsonSettings.Settings));

        [JsonProperty("timestamp")]
        public DateTime Timestamp { get; internal set; }
        [JsonProperty("event")]
        public string Event { get; internal set; }
        [JsonProperty("From")]
        public string From { get; internal set; }
        [JsonProperty("From_Localised")]
        public string FromLocalised { get; internal set; }
        [JsonProperty("Message")]
        public string Message { get; internal set; }
        [JsonProperty("Message_Localised")]
        public string MessageLocalised { get; internal set; }
        [JsonProperty("Channel")]
        public string Channel { get; internal set; }
    }
}
