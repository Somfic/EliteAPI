using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace EliteAPI.Tests.Events
{
    public class Result
    {
        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("path")]
        public string Path { get; set; }

        [JsonProperty("line")]
        public Line Line { get; set; }

        [JsonProperty("level")]
        public string Level { get; set; } = "notice";
    }

    public struct Line
    {
        public Line(int line)
        {
            Start = line;
            End = line;
        }

        public Line(int start, int end)
        {
            Start = start;
            End = end;
        }

        [JsonProperty("start")]
        public long Start { get; private set; }

        [JsonProperty("end")]
        public long End { get; private set; }
    }
}
