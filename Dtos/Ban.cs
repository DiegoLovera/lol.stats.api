using System.Text.Json.Serialization;

namespace lol.stats.api.Dtos
{
    public class Ban
    {
        [JsonPropertyName("championId")]
        public long ChampionId { get; set; }

        [JsonPropertyName("pickTurn")]
        public long PickTurn { get; set; }
    }
}
