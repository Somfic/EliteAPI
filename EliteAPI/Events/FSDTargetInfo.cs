using Newtonsoft.Json;

namespace EliteAPI.Events
{
    //{ "timestamp":"2019-10-15T17:50:50Z", "event":"FSDTarget", "Name":"Crucis Sector JC-V b2-5", "SystemAddress":11666607580601, "RemainingJumpsInRoute":2 }

    public class FSDTargetInfo : EventBase
    {
        [JsonProperty("Name")]
        public string Name { get; internal set; }

        [JsonProperty("SystemAddress")]
        public long SystemAddress { get; internal set; }

        [JsonProperty("RemainingJumpsInRoute")]
        public int RemainingJumpsInRoute { get; internal set; }

        internal static FSDTargetInfo Process(string json, EliteDangerousAPI api)
        {
            return api.Events.InvokeFSDTargetEvent(JsonConvert.DeserializeObject<FSDTargetInfo>(json, JsonSettings.Settings));
        }
    }
}