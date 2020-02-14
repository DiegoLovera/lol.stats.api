using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace lol.stats.api.Dtos
{
    public class SummonerMatches
    {
        [JsonPropertyName("matches")]
        public List<Match> Matches { get; set; }

        [JsonPropertyName("startIndex")]
        public long StartIndex { get; set; }

        [JsonPropertyName("endIndex")]
        public long EndIndex { get; set; }

        [JsonPropertyName("totalGames")]
        public long TotalGames { get; set; }
    }
}
