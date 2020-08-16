using Newtonsoft.Json;

namespace EliteAPI.Event.Models.Startup
{
    /// <summary>
    /// This event is written when the game has started.
    /// </summary>
    public class CommanderEvent : EventBase
    {
        internal CommanderEvent() { }

        public static CommanderEvent FromJson(string json) => JsonConvert.DeserializeObject<CommanderEvent>(json);



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

        
    }
}