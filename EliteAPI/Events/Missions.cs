using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EliteAPI
{
    public class MissionsInfo
    {
        public class Mission
        {
            public int MissionID { get; }
            public string Name { get; }
            public bool PassengerMission { get; }
            public int Expires { get; }
        }

        public DateTime timestamp { get; }
        public List<Mission> Active { get; }
        public List<Mission> Failed { get; }
        public List<Mission> Complete { get; }
    }
}
