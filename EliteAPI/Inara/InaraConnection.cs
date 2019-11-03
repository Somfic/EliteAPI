using System;
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
    public class InaraEntry
    {
        public InaraEntry(InaraConfiguration configuration, List<InaraEvent> events)
        {
            Configuration = configuration;
            Events = events;
        }
        [JsonProperty("header")]
        public InaraConfiguration Configuration { get; internal set; }
        [JsonProperty("events")]
        public List<InaraEvent> Events { get; internal set; }
    }
    public class InaraConfiguration
    {
        public InaraConfiguration(string apiKey, string appName, string appVersion)
        {
            ApiKey = apiKey;
            AppName = appName;
            AppVersion = appVersion;
        }
        [JsonProperty("appName")]
        public string AppName { get; internal set; }
        [JsonProperty("appVersion")]
        public string AppVersion { get; internal set; }
        [JsonProperty("isDeveloped")]
        public bool? IsDeveloped { get; internal set; }
        [JsonProperty("APIkey")]
        public string ApiKey { get; internal set; }
        [JsonProperty("commanderName")]
        public string CommanderName { get; internal set; }
        [JsonProperty("commanderFrontierID")]
        public string CommanderFrontierId { get; internal set; }
    }
    public class InaraEvent
    {
        public InaraEvent(IInaraEventData eventData)
        {
            EventData = eventData;
        }
        [JsonProperty("eventName")]
        string EventName { get => EventData.GetType().Name; }
        [JsonProperty("eventTimestamp")]
        string EventTimestamp { get => DateTime.UtcNow.ToString("o"); }
        [JsonProperty("eventData")]
        IInaraEventData EventData { get; set; }
    }
    public interface IInaraEventData
    {
    }
}