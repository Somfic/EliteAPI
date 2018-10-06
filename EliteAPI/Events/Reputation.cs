using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EliteAPI.Events
{
    public class Reputation
    {
        public DateTime timestamp { get; set; }
        public string @event { get; set; }
        public double Empire { get; set; }
        public double Federation { get; set; }
        public double Alliance { get; set; }
    }
}
