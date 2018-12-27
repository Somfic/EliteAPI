using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using EliteAPI;

namespace Example
{
    class Program
    {
        static void Main(string[] args)
        {
            EliteDangerousAPI api = new EliteDangerousAPI(new System.IO.DirectoryInfo(@"C:\Users\Lucas\Saved Games\Frontier Developments\Elite Dangerous"));
            api.SendTextEvent += Api_SendTextEvent;

            api.Start();
            Thread.Sleep(-1);
        }

        private static void Api_SendTextEvent(object sender, SendTextInfo e)
        {
            Console.WriteLine(e.To);
            Console.WriteLine(e.Message);
            Console.WriteLine("=");
        }
    }
}
