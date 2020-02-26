using MongoDB.Bson.Serialization.Attributes;
using System.Text.Json.Serialization;

namespace lol.stats.api.Dtos
{
    public class Participant
    {
        [BsonElement("participantId")]
        [JsonPropertyName("participantId")]
        public long ParticipantId { get; set; }

        [BsonElement("teamId")]
        [JsonPropertyName("teamId")]
        public long TeamId { get; set; }

        [BsonElement("championId")]
        [JsonPropertyName("championId")]
        public long ChampionId { get; set; }

        [BsonElement("spell1Id")]
        [JsonPropertyName("spell1Id")]
        public long Spell1Id { get; set; }

        [BsonElement("spell2Id")]
        [JsonPropertyName("spell2Id")]
        public long Spell2Id { get; set; }

        [BsonElement("stats")]
        [JsonPropertyName("stats")]
        public Stats Stats { get; set; }

        [BsonElement("timeline")]
        [JsonPropertyName("timeline")]
        public Timeline Timeline { get; set; }
    }
}
