using System;

namespace EliteAPI.Events
{
    using System.Collections.Generic;
    using Newtonsoft.Json;

    public class SendTextInfo : EventBase
    {
        internal static SendTextInfo Process(string json, EliteDangerousAPI api) => api.Events.InvokeSendTextEvent(JsonConvert.DeserializeObject<SendTextInfo>(json, JsonSettings.Settings));

        [JsonProperty("To")]
        public string To { get; internal set; }
        [JsonProperty("To_Localised")]
        public string ToLocalised { get; internal set; }
        [JsonProperty("Message")]
        public string Message { get; internal set; }
    }
}
