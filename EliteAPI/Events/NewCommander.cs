using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EliteAPI.Events
{
    public class NewCommander
    {
        public DateTime timestamp { get; set; }
        public string @event { get; set; }
        public string Name { get; set; }
        public string Package { get; set; }
    }
}
