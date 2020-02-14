using System.Text.Json.Serialization;

namespace lol.stats.api.Dtos
{
    public class Participant
    {
        [JsonPropertyName("participantId")]
        public long ParticipantId { get; set; }

        [JsonPropertyName("teamId")]
        public long TeamId { get; set; }

        [JsonPropertyName("championId")]
        public long ChampionId { get; set; }

        [JsonPropertyName("spell1Id")]
        public long Spell1Id { get; set; }

        [JsonPropertyName("spell2Id")]
        public long Spell2Id { get; set; }

        [JsonPropertyName("stats")]
        public Stats Stats { get; set; }

        [JsonPropertyName("timeline")]
        public Timeline Timeline { get; set; }
    }
}
