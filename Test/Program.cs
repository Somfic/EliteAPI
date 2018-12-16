using EliteAPI;
using System;
using System.IO;
using System.Threading;

namespace Example
{
    class Program
    {
        static void Main(string[] args)
        {
            EliteDangerousAPI EliteAPI = new EliteDangerousAPI(new DirectoryInfo($@"C:\Users\{Environment.UserName}\Saved Games\Frontier Developments\Elite Dangerous"), false);
            EliteAPI.Start();

            Thread.Sleep(-1);
        }
    }   
}
