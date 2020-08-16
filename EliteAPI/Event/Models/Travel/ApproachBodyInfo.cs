using Newtonsoft.Json;

namespace EliteAPI.Event.Models.Travel
{
    /// <summary>
    /// This event is written when in supercruise when entering a body's Orbital Zone.
    /// </summary>
    public class ApproachBodyEvent : EventBase
    {
        internal ApproachBodyEvent() { }

        public static ApproachBodyEvent FromJson(string json) => JsonConvert.DeserializeObject<ApproachBodyEvent>(json);



        /// <summary>
        /// The starsystem of the body.
        /// </summary>
        [JsonProperty("StarSystem")]
        public string StarSystem { get; internal set; }

        /// <summary>
        /// The address of the starsystem.
        /// </summary>
        [JsonProperty("SystemAddress")]
        public long SystemAddress { get; internal set; }

        /// <summary>
        /// The name of the body that is being approached.
        /// </summary>
        [JsonProperty("Body")]
        public string Body { get; internal set; }

        /// <summary>
        /// The ID of the body that is being approached.
        /// </summary>
        [JsonProperty("BodyID")]
        public long BodyId { get; internal set; }

        
    }
}