using System;
using System.Collections.Generic;

namespace EliteAPI
{
    public class EngineerProgressInfo
    {
        public DateTime timestamp { get; }
        public List<EngineerInfo> Engineers { get; }

        public class EngineerInfo
        {
            public string Engineer { get; }
            public int EngineerID { get; }
            public string Progress { get; }
            public int RankProgress { get; }
            public int Rank { get; }
        }

    }
}
