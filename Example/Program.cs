using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft;
using EliteAPI;
using System.Xml;
using EliteAPI.Bindings;

namespace Example
{
    class Program
    {
        static void Main(string[] args)
        {
            EliteDangerousAPI api = new EliteDangerousAPI(new System.IO.DirectoryInfo(@"C:\Users\Lucas\Saved Games\Frontier Developments\Elite Dangerous"), false);
            api.OtherEvent += (sender, arg) => File.AppendAllText(@"C:\ICT\EliteAPI\NotAddedEvents.txt", JsonConvert.SerializeObject(arg) + Environment.NewLine);
            api.Start();

            api.Bindings.Root.PitchUpButton.Primary.Key;

            Thread.Sleep(-1);
        }
    }
}
