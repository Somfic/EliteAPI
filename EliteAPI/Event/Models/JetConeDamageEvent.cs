using EliteAPI.Event.Models;
using EliteAPI.Event.Models.Abstractions;

namespace EliteAPI.Event.Models
{
    public partial class JetConeDamageEvent : EventBase
    {
        internal JetConeDamageEvent()
        {
        }

        [JsonProperty("Module")] public string Module { get; private set; }

        [JsonProperty("Module_Localised")] public string ModuleLocalised { get; private set; }
    }

    public partial class JetConeDamageEvent
    {
        public static JetConeDamageEvent FromJson(string json)
        {
            return JsonConvert.DeserializeObject<JetConeDamageEvent>(json);
        }
    }
}

namespace EliteAPI.Event.Handler
{
    public partial class EventHandler
    {
        public event EventHandler<JetConeDamageEvent> JetConeDamageEvent;

        internal void InvokeJetConeDamageEvent(JetConeDamageEvent arg)
        {
            JetConeDamageEvent?.Invoke(this, arg);
        }
    }
}