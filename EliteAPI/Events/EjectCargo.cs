using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EliteAPI
{
    public class EjectCargoInfo
    {
        public DateTime timestamp { get; }
        public string Type { get; }
        public string Type_Localised { get; }
        public int Count { get; }
        public bool Abandoned { get; }
    }
}
