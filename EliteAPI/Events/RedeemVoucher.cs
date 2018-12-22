using System;
using System.Collections.Generic;

namespace EliteAPI
{
    public class RedeemVoucherInfo
    {
        public DateTime timestamp { get; }
        public string Type { get; }
        public int Amount { get; }
        public List<FactionInfo> Factions { get; }
    }

    public class FactionInfo
    {
        public string Faction { get; }
        public int Amount { get; }
    }
}
