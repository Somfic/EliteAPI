using System;
using System.Collections.Generic;

namespace EliteAPI
{
    public class LoadoutInfo
    {
        public class ModifierInfo
        {
            public string Label { get; }
            public double Value { get; }
            public double OriginalValue { get; }
            public int LessIsGood { get; }
        }

        public class EngineeringInfo
        {
            public string Engineer { get; }
            public int EngineerID { get; }
            public int BlueprintID { get; }
            public string BlueprintName { get; }
            public int Level { get; }
            public double Quality { get; }
            public List<ModifierInfo> Modifiers { get; }
        }

        public class ModuleInfo
        {
            public string Slot { get; }
            public string Item { get; }
            public bool On { get; }
            public int Priority { get; }
            public double Health { get; }
            public int Value { get; }
            public int? AmmoInClip { get; }
            public int? AmmoInHopper { get; }
            public EngineeringInfo Engineering { get; }
        }

        public DateTime timestamp { get; }
        public string Ship { get; }
        public int ShipID { get; }
        public string ShipName { get; }
        public string ShipIdent { get; }
        public int HullValue { get; }
        public int ModulesValue { get; }
        public int Rebuy { get; }
        public List<ModuleInfo> Modules { get; }
    }
}
