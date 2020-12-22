using EliteAPI.Event.Models;
using EliteAPI.Event.Models.Abstractions;

namespace EliteAPI.Event.Models
{
    public partial class SynthesisEvent : EventBase
    {
        internal SynthesisEvent()
        {
        }

        [JsonProperty("Name")] public string Name { get; private set; }

        [JsonProperty("Materials")] public IReadOnlyList<Material> Materials { get; private set; }
    }

    public class Material
    {
        internal Material()
        {
        }

        [JsonProperty("Name")] public string Name { get; private set; }

        [JsonProperty("Count")] public long Count { get; private set; }
    }

    public partial class SynthesisEvent
    {
        public static SynthesisEvent FromJson(string json)
        {
            return JsonConvert.DeserializeObject<SynthesisEvent>(json);
        }
    }
}

namespace EliteAPI.Event.Handler
{
    public partial class EventHandler
    {
        public event EventHandler<SynthesisEvent> SynthesisEvent;

        internal void InvokeSynthesisEvent(SynthesisEvent arg)
        {
            SynthesisEvent?.Invoke(this, arg);
        }
    }
}