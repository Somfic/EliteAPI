using EliteAPI.Event.Models.Abstractions;
using Newtonsoft.Json;

namespace EliteAPI.Event.Models
{
    public class WingLeaveEvent : EventBase
    {
        internal WingLeaveEvent() { }

        public static WingLeaveEvent FromJson(string json) => JsonConvert.DeserializeObject<WingLeaveEvent>(json);


        
    }
}