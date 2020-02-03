using Newtonsoft.Json;

namespace EliteAPI.Events.Startup
{
    /// <summary>
    /// This event is written when the game has started.
    /// </summary>
    public class CommanderInfo : EventBase
    {
        internal CommanderInfo() { }

        /// <summary>
        /// The commander's Frontier ID.
        /// </summary>
        [JsonProperty("FID")]
        public string FID { get; internal set; }

        /// <summary>
        /// The commander's name.
        /// </summary>
        [JsonProperty("Name")]
        public string Name { get; internal set; }

        internal static CommanderInfo Process(string json, EliteDangerousAPI api)
        {
            return api.Events.InvokeCommanderEvent(JsonConvert.DeserializeObject<CommanderInfo>(json, JsonSettings.Settings));
        }
    }
}