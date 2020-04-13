using System.Data;
using Somfic.Logging;
using System.IO;
using EliteAPI.Events;
using Newtonsoft.Json;

namespace EliteAPI.Status
{
    internal static class StatusReader
    {
        public static T Read<T>(string path) where T : IStatus
        {
            return JsonConvert.DeserializeObject<T>(FileReader.ReadAllText(path));
        }
    }
}
