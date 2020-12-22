using EliteAPI.Event.Models;
using EliteAPI.Event.Models.Abstractions;

namespace EliteAPI.Event.Models
{
    public partial class UssDropEvent : EventBase
    {
        internal UssDropEvent()
        {
        }

        [JsonProperty("USSType")] public string UssType { get; private set; }

        [JsonProperty("USSType_Localised")] public string UssTypeLocalised { get; private set; }

        [JsonProperty("USSThreat")] public long UssThreat { get; private set; }
    }

    public partial class UssDropEvent
    {
        public static UssDropEvent FromJson(string json)
        {
            return JsonConvert.DeserializeObject<UssDropEvent>(json);
        }
    }
}

namespace EliteAPI.Event.Handler
{
    public partial class EventHandler
    {
        public event EventHandler<UssDropEvent> UssDropEvent;

        internal void InvokeUssDropEvent(UssDropEvent arg)
        {
            UssDropEvent?.Invoke(this, arg);
        }
    }
}