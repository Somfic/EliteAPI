using Newtonsoft.Json;

namespace EliteAPI.Events.Startup
{
    /// <summary>
    /// Contains statistics on the commander's passenger missions.
    /// </summary>
    /// <see cref="StatisticsInfo"/>
    public class StatisticsPassengersInfo
    {
        internal StatisticsPassengersInfo() { }

        /// <summary>
        /// The amount of passenger missions done.
        /// </summary>
        [JsonProperty("Passengers_Missions_Accepted")]
        public int PassengersMissionsAccepted { get; internal set; }

        /// <summary>
        /// The amount of passenger missions cancelled.
        /// </summary>
        [JsonProperty("Passengers_Missions_Disgruntled")]
        public int PassengersMissionsDisgruntled { get; internal set; }

        /// <summary>
        /// The about of bulk passenger missions done.
        /// </summary>
        [JsonProperty("Passengers_Missions_Bulk")]
        public int PassengersMissionsBulk { get; internal set; }

        /// <summary>
        /// The amount of VIP passenger missions done.
        /// </summary>
        [JsonProperty("Passengers_Missions_VIP")]
        public long PassengersMissionsVip { get; internal set; }

        /// <summary>
        /// The amount of passenger missions completed.
        /// </summary>
        [JsonProperty("Passengers_Missions_Delivered")]
        public long PassengersMissionsDelivered { get; internal set; }

        /// <summary>
        /// The amount of passenger missions ejected.
        /// </summary>
        [JsonProperty("Passengers_Missions_Ejected")]
        public long PassengersMissionsEjected { get; internal set; }
    }
}