using Newtonsoft.Json;

namespace EliteAPI.Events
{
    public class Crime
    {
        [JsonProperty("Notoriety")]
        public long Notoriety { get; internal set; }

        [JsonProperty("Fines")]
        public long Fines { get; internal set; }

        [JsonProperty("Total_Fines")]
        public long TotalFines { get; internal set; }

        [JsonProperty("Bounties_Received")]
        public long BountiesReceived { get; internal set; }

        [JsonProperty("Total_Bounties")]
        public long TotalBounties { get; internal set; }

        [JsonProperty("Highest_Bounty")]
        public long HighestBounty { get; internal set; }
    }
}