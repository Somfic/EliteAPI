using System;
using System.Collections.Generic;

namespace EliteAPI
{
    public class ModulesInfo
    {
        public DateTime timestamp { get; }
        public List<Module> Modules { get; }
    }

    public class Module
    {
        public string Slot { get; }
        public string Item { get; }
        public float Power { get; }
        public int Priority { get; }
    }
}
