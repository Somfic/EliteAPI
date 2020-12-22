using EliteAPI.Event.Models;
using EliteAPI.Event.Models.Abstractions;

namespace EliteAPI.Event.Models
{
    public partial class DatalinkScanEvent : EventBase
    {
        internal DatalinkScanEvent()
        {
        }

        [JsonProperty("Message")] public string Message { get; private set; }

        [JsonProperty("Message_Localised")] public string MessageLocalised { get; private set; }
    }

    public partial class DatalinkScanEvent
    {
        public static DatalinkScanEvent FromJson(string json)
        {
            return JsonConvert.DeserializeObject<DatalinkScanEvent>(json);
        }
    }
}

namespace EliteAPI.Event.Handler
{
    public partial class EventHandler
    {
        public event EventHandler<DatalinkScanEvent> DatalinkScanEvent;

        internal void InvokeDatalinkScanEvent(DatalinkScanEvent arg)
        {
            DatalinkScanEvent?.Invoke(this, arg);
        }
    }
}