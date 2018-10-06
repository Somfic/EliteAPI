using System;

using EliteAPI;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            EliteDangerousAPI API = new EliteDangerousAPI(new System.IO.DirectoryInfo(@"C:\Users\Lucas\Saved Games\Frontier Developments\Elite Dangerous"));        }
    }
}
