using System.Collections.Generic;
using System.IO;
using System.Net;
using Newtonsoft.Json;
namespace EliteAPI.Inara
{
    public class InaraConnection
    {
        public List<InaraEvent> EventsQueue = new List<InaraEvent>();
        public string ExecuteQueue(InaraConfiguration header)
        {
            InaraEntry entry = new InaraEntry(header, EventsQueue);
            string result = Execute(entry);
            EventsQueue.Clear();
            return result;
        }
        public string Execute(InaraEntry entry)
        { 
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://inara.cz/inapi/v1/");
            request.ContentType = "application/json";
            request.Method = "POST";
            StreamWriter writer = new StreamWriter(request.GetRequestStream());
            writer.Write(JsonConvert.SerializeObject(entry));
            writer.Flush();
            writer.Close();
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            StreamReader reader = new StreamReader(response.GetResponseStream());
            return reader.ReadToEnd();
        }
    }
}