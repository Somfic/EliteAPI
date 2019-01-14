using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using Newtonsoft.Json;

namespace EliteAPI.Inara
{
    public class InaraConnection
    {
        public List<InaraEvent> EventsQueue = new List<InaraEvent>();

        public string ExecuteQueue(InaraHeader header)
        {
            InaraEntry entry = new InaraEntry(header, EventsQueue);
            EventsQueue.Clear();

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
        public InaraEntry(InaraHeader header, List<InaraEvent> events)
        {
            Header = header;
            Events = events;
        }

        [JsonProperty("header")]
        public InaraHeader Header { get; set; }

        [JsonProperty("events")]
        public List<InaraEvent> Events { get; set; }
    }

    public class InaraHeader
    {
        public InaraHeader(string apiKey, string appName, string appVersion)
        {
            ApiKey = apiKey;
            AppName = appName;
            AppVersion = appVersion;
        }

        [JsonProperty("appName")]
        public string AppName { get; set; }

        [JsonProperty("appVersion")]
        public string AppVersion { get; set; }

        [JsonProperty("isDeveloped")]
        public bool? IsDeveloped { get; set; }

        [JsonProperty("APIkey")]
        public string ApiKey { get; set; }

        [JsonProperty("commanderName")]
        public string CommanderName { get; set; }

        [JsonProperty("commanderFrontierID")]
        public string CommanderFrontierId { get; set; }
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
        string EventTimestamp { get => DateTime.Now.ToString(); }

        [JsonProperty("eventData")]
        IInaraEventData EventData { get; set; }
    }

    public interface IInaraEventData
    {
    }
}