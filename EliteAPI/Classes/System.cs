using System;
using System.Collections.Generic;

namespace EliteAPI
{
    public class System
    {
        public string Name { get; internal set; }
        public List<double> Position { get; internal set; }
        public long Address { get; internal set; }
        public string Allegiance { get; internal set; }
        public string Economy { get; internal set; }
        public string Economy_Localised { get; internal set; }
        public string SecondEconomy { get; internal set; }
        public string SecondEconomy_Localised { get; internal set; }
        public string Government { get; internal set; }
        public string Government_Localised { get; internal set; }
        public string Security { get; internal set; }
        public string Security_Localised { get; internal set; }
        public ulong Population { get; internal set; }
        public string SystemFaction { get; internal set; }
        public string FactionState { get; internal set; }
    }
}
