using System;

namespace EliteAPI.Events
{
    using System.Collections.Generic;
    using Newtonsoft.Json;

    public class SendTextInfo : IEvent
    {
        internal static SendTextInfo Process(string json, EliteDangerousAPI api) => api.Events.InvokeSendTextEvent(JsonConvert.DeserializeObject<SendTextInfo>(json, EliteAPI.Events.SendTextConverter.Settings));

        [JsonProperty("timestamp")]
        public DateTime Timestamp { get; internal set; }
        [JsonProperty("event")]
        public string Event { get; internal set; }
        [JsonProperty("To")]
        public string To { get; internal set; }
        [JsonProperty("To_Localised")]
        public string ToLocalised { get; internal set; }
        [JsonProperty("Message")]
        public string Message { get; internal set; }
    }
}
