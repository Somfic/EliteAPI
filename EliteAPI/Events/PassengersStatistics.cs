namespace EliteAPI.Events
{
    using Newtonsoft.Json;

    public class PassengersStatistics
    {
        [JsonProperty("Passengers_Missions_Accepted")]
        public long PassengersMissionsAccepted { get; internal set; }
        [JsonProperty("Passengers_Missions_Disgruntled")]
        public long PassengersMissionsDisgruntled { get; internal set; }
        [JsonProperty("Passengers_Missions_Bulk")]
        public long PassengersMissionsBulk { get; internal set; }
        [JsonProperty("Passengers_Missions_VIP")]
        public long PassengersMissionsVip { get; internal set; }
        [JsonProperty("Passengers_Missions_Delivered")]
        public long PassengersMissionsDelivered { get; internal set; }
        [JsonProperty("Passengers_Missions_Ejected")]
        public long PassengersMissionsEjected { get; internal set; }
    }
}
