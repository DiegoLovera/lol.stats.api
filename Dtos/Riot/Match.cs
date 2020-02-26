using System.Text.Json.Serialization;

namespace lol.stats.api.Dtos
{
    public class Match
    {
        [JsonPropertyName("platformId")]
        public PlatformId PlatformId { get; set; }

        [JsonPropertyName("gameId")]
        public long GameId { get; set; }

        [JsonPropertyName("champion")]
        public long Champion { get; set; }

        [JsonPropertyName("queue")]
        public long Queue { get; set; }

        [JsonPropertyName("season")]
        public long Season { get; set; }

        [JsonPropertyName("timestamp")]
        public long Timestamp { get; set; }

        [JsonPropertyName("role")]
        public Role Role { get; set; }

        [JsonPropertyName("lane")]
        public Lane Lane { get; set; }
    }
}
