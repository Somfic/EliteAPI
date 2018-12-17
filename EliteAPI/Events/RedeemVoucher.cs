using System;
using System.Collections.Generic;

namespace EliteAPI
{
    public class RedeemVoucherInfo
    {
        public DateTime timestamp { get; set; }
        public string Type { get; set; }
        public int Amount { get; set; }
        public List<FactionInfo> Factions { get; set; }
    }

    public class FactionInfo
    {
        public string Faction { get; set; }
        public int Amount { get; set; }
    }
}
