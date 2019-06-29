using System;

namespace EliteAPI
{
    public class LoadGameInfo
    {
        public DateTime timestamp { get; set; }
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
