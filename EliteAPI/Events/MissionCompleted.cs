using System;
using System.Collections.Generic;

namespace EliteAPI
{
    public class MissionCompletedInfo
    {
        public class EffectInfo
        {
            public string Effect { get; }
            public string Effect_Localised { get; }
            public string Trend { get; }
        }

        public class InfluenceInfo
        {
            public object SystemAddress { get; }
            public string Trend { get; }
        }

        public class FactionEffectInfo
        {
            public string Faction { get; }
            public List<EffectInfo> Effects { get; }
            public List<InfluenceInfo> Influence { get; }
            public string Reputation { get; }
        }

        public DateTime timestamp { get; }
        public string Faction { get; }
        public string Name { get; }
        public int MissionID { get; }
        public string TargetFaction { get; }
        public string DestinationSystem { get; }
        public string DestinationStation { get; }
        public int Reward { get; }
        public List<FactionEffectInfo> FactionEffects { get; }
    }
}
