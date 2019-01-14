using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;

using EliteAPI;
using EliteAPI.Inara;
using EliteAPI.Inara.Events;

namespace Example
{
    class Program
    {
        static void Main(string[] args)
        {
            InaraConnection inara = new InaraConnection();
            InaraHeader header = new InaraHeader("token", "EliteAPI", "2.0.0.0");
            List<InaraEvent> events = new List<InaraEvent>
            {
                new InaraEvent(new SetCommanderRankPilot(RankType.Combat) {RankValue = 6 })
            };
            Console.WriteLine(inara.Post(new InaraEntry(header, events)));
            Console.Read();
        }
    }
}
