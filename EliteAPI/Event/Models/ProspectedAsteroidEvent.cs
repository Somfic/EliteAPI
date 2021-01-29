using System;
using System.Collections.Generic;

using EliteAPI.Event.Models;
using EliteAPI.Event.Models.Abstractions;

using Newtonsoft.Json;

namespace EliteAPI.Event.Models
{


    public partial class ProspectedAsteroidEvent : EventBase
    {
        internal ProspectedAsteroidEvent() { }

        [JsonProperty("Materials")]
        public IReadOnlyList<Material> Materials { get; private set; }

        [JsonProperty("Content")]
        public string Content { get; private set; }

        [JsonProperty("Content_Localised")]
        public string ContentLocalised { get; private set; }

        [JsonProperty("Remaining")]
        public double Remaining { get; private set; }
    }

    public class Material
    {
        internal Material() { }

        [JsonProperty("Name")]
        public string Name { get; private set; }

        [JsonProperty("Name_Localised", NullValueHandling = NullValueHandling.Ignore)]
        public string NameLocalised { get; private set; }

        [JsonProperty("Proportion")]
        public double Proportion { get; private set; }
    }

    public partial class ProspectedAsteroidEvent
    {
        public static ProspectedAsteroidEvent FromJson(string json)
        {
            return JsonConvert.DeserializeObject<ProspectedAsteroidEvent>(json);
        }
    }


}

namespace EliteAPI.Event.Handler
{

    public partial class EventHandler
    {
        public event EventHandler<ProspectedAsteroidEvent> ProspectedAsteroidEvent;
        internal void InvokeProspectedAsteroidEvent(ProspectedAsteroidEvent arg)
        {
            ProspectedAsteroidEvent?.Invoke(this, arg);
        }
    }
}