using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EliteAPI
{
    public class StartJumpInfo
    {
        public DateTime timestamp { get; set; }
        public string @event { get; set; }
        public string JumpType { get; set; }
        public string StarSystem { get; set; }
        public long SystemAddress { get; set; }
        public string StarClass { get; set; }
    }
}
