using EliteAPI.Event.Models;
using EliteAPI.Event.Models.Abstractions;

namespace EliteAPI.Event.Models
{
    public partial class PowerplayVoteEvent : EventBase
    {
        internal PowerplayVoteEvent()
        {
        }

        [JsonProperty("Power")] public string Power { get; private set; }

        [JsonProperty("Votes")] public long Votes { get; private set; }

        [JsonProperty("")] public long Empty { get; private set; }
    }

    public partial class PowerplayVoteEvent
    {
        public static PowerplayVoteEvent FromJson(string json)
        {
            return JsonConvert.DeserializeObject<PowerplayVoteEvent>(json);
        }
    }
}

namespace EliteAPI.Event.Handler
{
    public partial class EventHandler
    {
        public event EventHandler<PowerplayVoteEvent> PowerplayVoteEvent;

        internal void InvokePowerplayVoteEvent(PowerplayVoteEvent arg)
        {
            PowerplayVoteEvent?.Invoke(this, arg);
        }
    }
}