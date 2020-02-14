using System.Text.Json.Serialization;

namespace lol.stats.api.Dtos
{
    public class ParticipantIdentity
    {
        [JsonPropertyName("participantId")]
        public long ParticipantId { get; set; }

        [JsonPropertyName("player")]
        public Player Player { get; set; }
    }
}
