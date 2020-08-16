using Newtonsoft.Json;

namespace EliteAPI.Event.Models.Startup
{
    /// <summary>
    /// This event is written when creating a new commander.
    /// </summary>
    public class NewCommanderEvent : EventBase
    {
        internal NewCommanderEvent() { }

        public static NewCommanderEvent FromJson(string json) => JsonConvert.DeserializeObject<NewCommanderEvent>(json);



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

        
    }
}