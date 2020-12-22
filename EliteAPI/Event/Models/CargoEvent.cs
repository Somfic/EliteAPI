using EliteAPI.Event.Models;
using EliteAPI.Event.Models.Abstractions;

namespace EliteAPI.Event.Models
{
    public partial class CargoEvent : EventBase
    {
        internal CargoEvent()
        {
        }

        [JsonProperty("Vessel")] public string Vessel { get; private set; }

        [JsonProperty("Count")] public long Count { get; private set; }

        [JsonProperty("Inventory")] public IReadOnlyList<object> Inventory { get; private set; }
    }

    public partial class CargoEvent
    {
        public static CargoEvent FromJson(string json)
        {
            return JsonConvert.DeserializeObject<CargoEvent>(json);
        }
    }
}

namespace EliteAPI.Event.Handler
{
    public partial class EventHandler
    {
        public event EventHandler<CargoEvent> CargoEvent;

        internal void InvokeCargoEvent(CargoEvent arg)
        {
            CargoEvent?.Invoke(this, arg);
        }
    }
}