using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EliteAPI
{
    public class ProgressInfo
    {
        public DateTime timestamp { get; set; }

        public int Combat { get; set; }
        public int Trade { get; set; }
        public int Explore { get; set; }
        public int Empire { get; set; }
        public int Federation { get; set; }
        public int CQC { get; set; }
    }
}
