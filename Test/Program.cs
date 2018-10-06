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

            api.Start();

            while (true)
            {
                Console.Clear();
                Console.WriteLine(api.lastSystem.Name);
                Console.Read();
            }
        }
    }
} 
