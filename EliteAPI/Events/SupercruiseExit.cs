using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EliteAPI
{
    public class SupercruiseExitInfo
    {
        public DateTime timestamp { get; set; }

        public string StarSystem { get; set; }
        public long SystemAddress { get; set; }
        public string Body { get; set; }
        public int BodyID { get; set; }
        public string BodyType { get; set; }
    }
}
