using System.Collections.Generic;
using Newtonsoft.Json;

namespace EliteAPI.Events
{
    public class WingJoinInfo : EventBase
    {
        [JsonProperty("Others")]
        public List<string> Others { get; internal set; }

        internal static WingJoinInfo Process(string json, EliteDangerousAPI api)
        {
            return api.Events.InvokeWingJoinEvent(JsonConvert.DeserializeObject<WingJoinInfo>(json, JsonSettings.Settings));
        }
    }
}