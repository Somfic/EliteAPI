using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EliteAPI
{
    public class TouchdownInfo
    {
        public DateTime timestamp { get; }
        public bool PlayerControlled { get; }
        public double Latitude { get; }
        public double Longitude { get; }
    }
}
