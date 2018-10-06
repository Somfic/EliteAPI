using System;
using System.Threading;

using EliteAPI;

namespace Example
{
    class Program
    {
        static void Main(string[] args)
        {
            EliteDangerousAPI api = new EliteDangerousAPI(new System.IO.DirectoryInfo(@"C:\Users\Lucas\Saved Games\Frontier Developments\Elite Dangerous"));

            api.ShipTargetedEvent += Api_ShipTargetedEvent;

            api.Start();

            Thread.Sleep(-1);
        }

        private static void Api_ShipTargetedEvent(object sender, ShipTargetedInfo e)
        {
            if(e.Bounty > 0) { Console.Beep(); }
        }
    }
}
