using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EliteAPI.Events
{
    public class LoadGame
    {
        public DateTime timestamp { get; set; }
        public string @event { get; set; }
        public string Commander { get; set; }
        public bool Horizons { get; set; }
        public string Ship { get; set; }
        public int ShipID { get; set; }
        public string ShipName { get; set; }
        public string ShipIdent { get; set; }
        public double FuelLevel { get; set; }
        public double FuelCapacity { get; set; }
        public string GameMode { get; set; }
        public int Credits { get; set; }
        public int Loan { get; set; }
    }
}
