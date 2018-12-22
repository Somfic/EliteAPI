using System;

namespace EliteAPI
{
    public class LoadGameInfo
    {
        public DateTime timestamp { get; }
        public string Commander { get; }
        public bool Horizons { get; }
        public string Ship { get; }
        public int ShipID { get; }
        public string ShipName { get; }
        public string ShipIdent { get; }
        public double FuelLevel { get; }
        public double FuelCapacity { get; }
        public string GameMode { get; }
        public int Credits { get; }
        public int Loan { get; }
    }
}
