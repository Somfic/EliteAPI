using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EliteAPI
{
    public class Loadout
    {
        public class Modifier
        {
            public string Label { get; set; }
            public double Value { get; set; }
            public double OriginalValue { get; set; }
            public int LessIsGood { get; set; }
        }

        public class Engineering
        {
            public string Engineer { get; set; }
            public int EngineerID { get; set; }
            public int BlueprintID { get; set; }
            public string BlueprintName { get; set; }
            public int Level { get; set; }
            public double Quality { get; set; }
            public List<Modifier> Modifiers { get; set; }
        }

        public class Module
        {
            public string Slot { get; set; }
            public string Item { get; set; }
            public bool On { get; set; }
            public int Priority { get; set; }
            public double Health { get; set; }
            public int Value { get; set; }
            public int? AmmoInClip { get; set; }
            public int? AmmoInHopper { get; set; }
            public Engineering Engineering { get; set; }
        }

        public DateTime timestamp { get; set; }
        public string @event { get; set; }
        public string Ship { get; set; }
        public int ShipID { get; set; }
        public string ShipName { get; set; }
        public string ShipIdent { get; set; }
        public int HullValue { get; set; }
        public int ModulesValue { get; set; }
        public int Rebuy { get; set; }
        public List<Module> Modules { get; set; }
    }
}
