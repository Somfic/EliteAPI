using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EliteAPI
{
    public class MissionCompletedInfo
    {
        public class EffectInfo
        {
            public string Effect { get; set; }
            public string Effect_Localised { get; set; }
            public string Trend { get; set; }
        }

        public class InfluenceInfo
        {
            public object SystemAddress { get; set; }
            public string Trend { get; set; }
        }

        public class FactionEffectInfo
        {
            public string Faction { get; set; }
            public List<EffectInfo> Effects { get; set; }
            public List<InfluenceInfo> Influence { get; set; }
            public string Reputation { get; set; }
        }

        public DateTime timestamp { get; set; }
        public string Faction { get; set; }
        public string Name { get; set; }
        public int MissionID { get; set; }
        public string TargetFaction { get; set; }
        public string DestinationSystem { get; set; }
        public string DestinationStation { get; set; }
        public int Reward { get; set; }
        public List<FactionEffectInfo> FactionEffects { get; set; }
    }
}
