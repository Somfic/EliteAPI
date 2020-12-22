using EliteAPI.Event.Models;
using EliteAPI.Event.Models.Abstractions;

namespace EliteAPI.Event.Models
{
    public partial class PayLegacyFinesEvent : EventBase
    {
        internal PayLegacyFinesEvent()
        {
        }

        [JsonProperty("Amount")] public long Amount { get; private set; }

        [JsonProperty("BrokerPercentage")] public double BrokerPercentage { get; private set; }
    }

    public partial class PayLegacyFinesEvent
    {
        public static PayLegacyFinesEvent FromJson(string json)
        {
            return JsonConvert.DeserializeObject<PayLegacyFinesEvent>(json);
        }
    }
}

namespace EliteAPI.Event.Handler
{
    public partial class EventHandler
    {
        public event EventHandler<PayLegacyFinesEvent> PayLegacyFinesEvent;

        internal void InvokePayLegacyFinesEvent(PayLegacyFinesEvent arg)
        {
            PayLegacyFinesEvent?.Invoke(this, arg);
        }
    }
}