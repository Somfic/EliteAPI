using System; 

using System.Collections.Generic;

namespace EliteAPI
{
    public class EngineerProgressInfo
    {
        public DateTime timestamp { get; set; }
        public List<EngineerInfo> Engineers { get; set; }

        public class EngineerInfo
        {
            public string Engineer { get; set; }
            public int EngineerID { get; set; }
            public string Progress { get; set; }
            public int RankProgress { get; set; }
            public int Rank { get; set; }
        }

    }
}
