using EliteAPI.Web.Models;
using Newtonsoft.Json;

namespace EliteAPI.Web.EDSM.Commander.Responses;

public class RanksResponse : IWebApiResponse
{
    internal RanksResponse()
    {
    }

    [JsonProperty("msgnum")]
    public long Status { get; set; }

    [JsonProperty("msg")]
    public string Message { get; set; }

    [JsonProperty("ranks")]
    public RankInfo<int> Ranks { get; set; }

    [JsonProperty("progress")]
    public RankInfo<int> Progress { get; set; }

    [JsonProperty("ranksVerbose")]
    public RankInfo<string> RanksVerbose { get; set; }

    public class RankInfo<T>
    {
        internal RankInfo()
        {
        }

        [JsonProperty("Combat")]
        public T Combat { get; set; }

        [JsonProperty("Trade")]
        public T Trade { get; set; }

        [JsonProperty("Explore")]
        public T Explore { get; set; }

        [JsonProperty("CQC")]
        public T Cqc { get; set; }

        [JsonProperty("Federation")]
        public T Federation { get; set; }

        [JsonProperty("Empire")]
        public T Empire { get; set; }
    }
}