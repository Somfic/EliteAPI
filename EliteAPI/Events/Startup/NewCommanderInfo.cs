using Newtonsoft.Json;

namespace EliteAPI.Events.Startup
{
    /// <summary>
    /// This event is written when creating a new commander.
    /// </summary>
    public class NewCommanderInfo : EventBase
    {
        internal NewCommanderInfo() { }

        /// <summary>
        /// The name of the commander.
        /// </summary>
        [JsonProperty("Name")]
        public string Name { get; internal set; }

        /// <summary>
        /// The Frontier ID of the commander.
        /// </summary>
        [JsonProperty("FID")]
        public string Fid { get; internal set; }

        /// <summary>
        /// The chosen starter package.
        /// </summary>
        [JsonProperty("Package")]
        public string Package { get; internal set; }

        internal static NewCommanderInfo Process(string json, EliteDangerousAPI api)
        {
            return api.Events.InvokeNewCommanderEvent(JsonConvert.DeserializeObject<NewCommanderInfo>(json, JsonSettings.Settings));
        }
    }
}