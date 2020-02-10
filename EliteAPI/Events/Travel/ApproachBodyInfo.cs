using Newtonsoft.Json;

namespace EliteAPI.Events.Travel
{
    /// <summary>
    /// This event is written when in supercruise when entering a body's Orbital Zone.
    /// </summary>
    public class ApproachBodyInfo : EventBase
    {
        internal ApproachBodyInfo() { }

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

        internal static ApproachBodyInfo Process(string json, EliteDangerousAPI api)
        {
            return api.Events.InvokeApproachBodyEvent(JsonConvert.DeserializeObject<ApproachBodyInfo>(json, JsonSettings.Settings));
        }
    }
}