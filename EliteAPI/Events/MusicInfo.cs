using Newtonsoft.Json;

namespace EliteAPI.Events
{
    public class MusicInfo : EventBase
    {
        [JsonProperty("MusicTrack")]
        public string MusicTrack { get; internal set; }

        internal static MusicInfo Process(string json, EliteDangerousAPI api)
        {
            return api.Events.InvokeMusicEvent(JsonConvert.DeserializeObject<MusicInfo>(json, JsonSettings.Settings));
        }
    }
}