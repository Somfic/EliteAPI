using System;
using System.Threading;
using System.Collections.Generic;

using System.IO;

using EliteAPI;
using EliteAPI.EDDB;

using Newtonsoft.Json;
using System.Linq;

namespace Example
{
    class Program
    {
        static void Main(string[] args)
        {
            EliteDangerousAPI EliteAPI = new EliteDangerousAPI(new DirectoryInfo($@"C:\Users\{Environment.UserName}\Saved Games\Frontier Developments\Elite Dangerous"));
            EliteAPI.Start();

            Thread.Sleep(-1);
        }
    }
}
