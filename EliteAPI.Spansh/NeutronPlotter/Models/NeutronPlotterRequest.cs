using System.Collections.Generic;
using Newtonsoft.Json;

namespace EliteAPI.Spansh.NeutronPlotter.Models
{
    public class NeutronPlotterResponse
    {
        [JsonProperty("result")] public NeutronPlotterResult Result { get; private set; } = new NeutronPlotterResult();

        [JsonProperty("status")] public string Status { get; private set; }


        public class NeutronPlotterResult
        {
            [JsonProperty("destination_system")] public string DestinationSystem { get; private set; }

            [JsonProperty("distance")] public double Distance { get; private set; }

            [JsonProperty("efficiency")]
            [JsonConverter(typeof(ParseStringConverter))]
            public long Efficiency { get; private set; }

            [JsonProperty("job")] public string Job { get; private set; }

            [JsonProperty("range")]
            [JsonConverter(typeof(ParseStringConverter))]
            public long Range { get; private set; }

            [JsonProperty("source_system")] public string SourceSystem { get; private set; }

            [JsonProperty("system_jumps")]
            public IReadOnlyList<SystemJump> SystemJumps { get; private set; } = new List<SystemJump>();

            [JsonProperty("total_jumps")] public long TotalJumps { get; private set; }

            [JsonProperty("via")] public IReadOnlyList<string> Via { get; private set; } = new List<string>();
        }

        public class SystemJump
        {
            [JsonProperty("distance_jumped")] public double DistanceJumped { get; private set; }

            [JsonProperty("distance_left")] public double DistanceLeft { get; private set; }

            [JsonProperty("id64")] public long Id64 { get; private set; }

            [JsonProperty("jumps")] public long Jumps { get; private set; }

            [JsonProperty("neutron_star")] public bool NeutronStar { get; private set; }

            [JsonProperty("system")] public string System { get; private set; }

            [JsonProperty("x")] public double X { get; private set; }

            [JsonProperty("y")] public double Y { get; private set; }

            [JsonProperty("z")] public double Z { get; private set; }
        }
    }
}