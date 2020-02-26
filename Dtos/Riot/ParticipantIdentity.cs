using MongoDB.Bson.Serialization.Attributes;
using System.Text.Json.Serialization;

namespace lol.stats.api.Dtos
{
    public class ParticipantIdentity
    {
        [BsonElement("participantId")]
        [JsonPropertyName("participantId")]
        public long ParticipantId { get; set; }

        [BsonElement("player")]
        [JsonPropertyName("player")]
        public Player Player { get; set; }
    }
}
