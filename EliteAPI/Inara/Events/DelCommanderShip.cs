using Newtonsoft.Json;
namespace EliteAPI.Inara.Events
{
    public class DelCommanderShip : IInaraEventData
    {
        public DelCommanderShip(string shipType, long shipGameId)
        {
            ShipType = shipType;
            ShipGameId = shipGameId;
        }
        [JsonProperty("shipType")]
        public string ShipType { get; internal set; }
        [JsonProperty("shipGameID")]
        public long ShipGameId { get; internal set; }
    }
}
