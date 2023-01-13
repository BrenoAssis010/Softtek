using Newtonsoft.Json;

namespace Questao2.Result
{
    public class CompetitionResult
    {
        [JsonProperty("page")]
        public int Page { get; set; }

        [JsonProperty("per_page")]
        public int PerPage { get; set; }

        [JsonProperty("total")]
        public int Total { get; set; }

        [JsonProperty("pages")]
        public int TotalPages { get; set; }

        [JsonProperty("data")]
        public List<TeamResult> Data { get; set; }
    }
}
