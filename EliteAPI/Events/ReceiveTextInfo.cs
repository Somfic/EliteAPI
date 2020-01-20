using System;

namespace EliteAPI.Events
{
    using System.Collections.Generic;
    using Newtonsoft.Json;

    public class ReceiveTextInfo : EventBase
    {
        internal static ReceiveTextInfo Process(string json, EliteDangerousAPI api) => api.Events.InvokeReceiveTextEvent(JsonConvert.DeserializeObject<ReceiveTextInfo>(json, JsonSettings.Settings));

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
