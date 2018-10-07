using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EliteAPI
{
    public class InterdictedInfo
    {
        public DateTime timestamp { get; set; }

        public bool Submitted { get; set; }
        public string Interdictor { get; set; }
        public bool IsPlayer { get; set; }
        public string Faction { get; set; }
    }
}
