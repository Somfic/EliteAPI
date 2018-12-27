using System;
using System.Collections.Generic;

namespace EliteAPI
{
    public class ModulesInfo
    {
        public DateTime timestamp { get; set; }
        public List<Module> Modules { get; set; }
    }

    public class Module
    {
        public string Slot { get; set; }
        public string Item { get; set; }
        public float Power { get; set; }
        public int Priority { get; set; }
    }
}
