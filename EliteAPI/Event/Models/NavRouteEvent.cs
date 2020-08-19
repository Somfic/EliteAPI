using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace EliteAPI.Event.Models
{
    public class NavRouteEvent : EventBase
    {
        internal NavRouteEvent() { }

        public static NavRouteEvent FromJson(string json) => JsonConvert.DeserializeObject<NavRouteEvent>(json);

    }
}
