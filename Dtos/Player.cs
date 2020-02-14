using System.Text.Json.Serialization;

namespace lol.stats.api.Dtos
{
    public class Player
    {
        [JsonPropertyName("platformId")]
        public PlatformId PlatformId { get; set; }

        [JsonPropertyName("accountId")]
        public string AccountId { get; set; }

        [JsonPropertyName("summonerName")]
        public string SummonerName { get; set; }

        [JsonPropertyName("summonerId")]
        public string SummonerId { get; set; }

        [JsonPropertyName("currentPlatformId")]
        public PlatformId CurrentPlatformId { get; set; }

        [JsonPropertyName("currentAccountId")]
        public string CurrentAccountId { get; set; }

        [JsonPropertyName("matchHistoryUri")]
        public string MatchHistoryUri { get; set; }

        [JsonPropertyName("profileIcon")]
        public long ProfileIcon { get; set; }
    }
}
