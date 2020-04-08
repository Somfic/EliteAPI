using System.Collections.Generic;
using Newtonsoft.Json;
namespace EliteAPI.Inara.Events
{
    public class SetCommanderShipLoadout : IInaraEventData
    {
        public SetCommanderShipLoadout(string shipType, long shipGameId)
        {
            ShipType = shipType;
            ShipGameId = shipGameId;
        }
        [JsonProperty("shipType")]
        public string ShipType { get; set; }
        [JsonProperty("shipGameID")]
        public long ShipGameId { get; set; }
        [JsonProperty("shipLoadout")]
        public List<InaraShipLoadout> ShipLoadout { get; set; }
    }
}
