using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Newtonsoft.Json;

namespace EliteAPI.Events
{
    public class ClearSavedGame
    {
        public DateTime timestamp { get; set; }
        public string @event { get; set; }
        public string Name { get; set; }
    }
}
