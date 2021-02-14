using System;

using EliteAPI.Event.Models;
using EliteAPI.Event.Models.Abstractions;

using Newtonsoft.Json;

using ProtoBuf;

namespace EliteAPI.Event.Models
{

    [ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
    public class CargoDepotEvent : EventBase<CargoDepotEvent>
    {
        internal CargoDepotEvent() { }

        [JsonProperty("MissionID")]
        public string MissionId { get; internal set; }

        [JsonProperty("UpdateType")]
        public string UpdateType { get; internal set; }

        [JsonProperty("CargoType")]
        public string CargoType { get; internal set; }

        [JsonProperty("CargoType_Localised")]
        public string CargoTypeLocalised { get; internal set; }

        [JsonProperty("Count")]
        public long Count { get; internal set; }

        [JsonProperty("StartMarketID")]
        public string StartMarketId { get; internal set; }

        [JsonProperty("EndMarketID")]
        public string EndMarketId { get; internal set; }

        [JsonProperty("ItemsCollected")]
        public long ItemsCollected { get; internal set; }

        [JsonProperty("ItemsDelivered")]
        public long ItemsDelivered { get; internal set; }

        [JsonProperty("TotalItemsToDeliver")]
        public long TotalItemsToDeliver { get; internal set; }

        [JsonProperty("Progress")]
        public double Progress { get; internal set; }
    }

}

namespace EliteAPI.Event.Handler
{
    public partial class EventHandler
    {
        public event EventHandler<CargoDepotEvent> CargoDepotEvent;

        internal void InvokeCargoDepotEvent(CargoDepotEvent arg)
        {
            CargoDepotEvent?.Invoke(this, arg);
        }
    }
}