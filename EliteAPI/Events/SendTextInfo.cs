using Newtonsoft.Json;

namespace EliteAPI.Events
{
    public class SendTextInfo : EventBase
    {
        [JsonProperty("To")]
        public string To { get; internal set; }

        [JsonProperty("To_Localised")]
        public string ToLocalised { get; internal set; }

        [JsonProperty("Message")]
        public string Message { get; internal set; }

        internal static SendTextInfo Process(string json, EliteDangerousAPI api)
        {
            return api.Events.InvokeSendTextEvent(JsonConvert.DeserializeObject<SendTextInfo>(json, JsonSettings.Settings));
        }
    }
}