using Newtonsoft.Json;

namespace EliteAPI.Events.Startup {
    /// <summary>
    /// An installed item on the ship.
    /// </summary>
    /// <see cref="LoadoutInfo"/>
    public class ModuleInfo
    {
        internal ModuleInfo() { }

        /// <summary>
        /// The name of the slot.
        /// </summary>
        [JsonProperty("Slot")]
        public string Slot { get; internal set; }

        /// <summary>
        /// The name of the module in this slow in lowercase.
        /// </summary>
        [JsonProperty("Item")]
        public string Item { get; internal set; }

        /// <summary>
        /// Whether this module is turned on.
        /// </summary>
        [JsonProperty("On")]
        public bool On { get; internal set; }

        /// <summary>
        /// The priority group of power for this module.
        /// </summary>
        [JsonProperty("Priority")]
        public int Priority { get; internal set; }

        /// <summary>
        /// The health of the module.
        /// </summary>
        [JsonProperty("Health")]
        public float Health { get; internal set; }

        /// <summary>
        /// The value of the module.
        /// </summary>
        [JsonProperty("Value", NullValueHandling = NullValueHandling.Ignore)]
        public long? Value { get; internal set; }

        /// <summary>
        /// Amount of ammunition in the clip.
        /// Can also be amount of places in a passenger cabin.
        /// </summary>
        [JsonProperty("AmmoInClip", NullValueHandling = NullValueHandling.Ignore)]
        public long? AmmoInClip { get; internal set; }

        /// <summary>
        /// The amount of ammunition in the hopper.
        /// </summary>
        [JsonProperty("AmmoInHopper", NullValueHandling = NullValueHandling.Ignore)]
        public long? AmmoInHopper { get; internal set; }

        /// <summary>
        /// The engineering that has been done on this module.
        /// </summary>
        /// <see cref="EngineeringInfo"/>
        [JsonProperty("Engineering", NullValueHandling = NullValueHandling.Ignore)]
        public EngineeringInfo EngineeringInfo { get; internal set; }
    }
}