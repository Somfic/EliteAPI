using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EliteAPI
{
    public class ScanInfo
    {
        public DateTime timestamp { get; set; }
        public string @event { get; set; }
        public string ScanType { get; set; }
    }
}
