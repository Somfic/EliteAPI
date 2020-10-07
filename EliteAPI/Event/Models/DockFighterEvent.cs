using EliteAPI.Event.Models.Abstractions;
using Newtonsoft.Json;

namespace EliteAPI.Event.Models
{
    public class DockFighterEvent : EventBase
    {
        internal DockFighterEvent() { }

        public static DockFighterEvent FromJson(string json) => JsonConvert.DeserializeObject<DockFighterEvent>(json);


        
    }
}