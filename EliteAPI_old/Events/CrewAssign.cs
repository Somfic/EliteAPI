using System; 

using System.Collections.Generic;

namespace EliteAPI
{
    public class CrewAssignInfo
    {
        public DateTime timestamp { get; set; }
        public String Name { get; set; }
        public Int64 CrewID { get; set; }
        public String Role { get; set; }
    }
}
