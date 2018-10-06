using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using EliteAPI;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            EliteDangerousAPI api = new EliteDangerousAPI(new System.IO.DirectoryInfo(@"C:\Users\Lucas\Saved Games\Frontier Developments\Elite Dangerous"));
            api.Start();

            api.
            Thread.Sleep(-1);
        }
    }
}
