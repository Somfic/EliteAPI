using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EliteAPI
{
    public class TouchdownInfo
    {
        public DateTime timestamp { get; set; }
        public bool PlayerControlled { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
    }
}
