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
            public int MissionID { get; set; }
            public string Name { get; set; }
            public bool PassengerMission { get; set; }
            public int Expires { get; set; }
        }

        public DateTime timestamp { get; set; }
        public List<Mission> Active { get; set; }
        public List<Mission> Failed { get; set; }
        public List<Mission> Complete { get; set; }
    }
}
