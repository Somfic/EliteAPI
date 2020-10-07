using Newtonsoft.Json;

namespace EliteAPI.Event.Models
{
    public class Effect
    {
        [JsonProperty("Effect")]
        public string EffectEffect { get; internal set; }

        [JsonProperty("Effect_Localised")]
        public string EffectLocalised { get; internal set; }

        [JsonProperty("Trend")]
        public string Trend { get; internal set; }
    }
}