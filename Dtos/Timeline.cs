using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json.Converters;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace lol.stats.api.Dtos
{
    public class Timeline
    {
        [BsonElement("participantId")]
        [JsonPropertyName("participantId")]
        public long ParticipantId { get; set; }

        [BsonElement("creepsPerMinDeltas")]
        [JsonPropertyName("creepsPerMinDeltas")]
        public Dictionary<string, double> CreepsPerMinDeltas { get; set; }

        [BsonElement("xpPerMinDeltas")]
        [JsonPropertyName("xpPerMinDeltas")]
        public Dictionary<string, double> XpPerMinDeltas { get; set; }

        [BsonElement("goldPerMinDeltas")]
        [JsonPropertyName("goldPerMinDeltas")]
        public Dictionary<string, double> GoldPerMinDeltas { get; set; }

        [BsonElement("csDiffPerMinDeltas")]
        [JsonPropertyName("csDiffPerMinDeltas")]
        public Dictionary<string, double> CsDiffPerMinDeltas { get; set; }

        [BsonElement("xpDiffPerMinDeltas")]
        [JsonPropertyName("xpDiffPerMinDeltas")]
        public Dictionary<string, double> XpDiffPerMinDeltas { get; set; }

        [BsonElement("damageTakenPerMinDeltas")]
        [JsonPropertyName("damageTakenPerMinDeltas")]
        public Dictionary<string, double> DamageTakenPerMinDeltas { get; set; }

        [BsonElement("damageTakenDiffPerMinDeltas")]
        [JsonPropertyName("damageTakenDiffPerMinDeltas")]
        public Dictionary<string, double> DamageTakenDiffPerMinDeltas { get; set; }

        [Newtonsoft.Json.JsonConverter(typeof(StringEnumConverter)), BsonRepresentation(BsonType.String), BsonElement("role")]
        [JsonPropertyName("role")]
        public Role Role { get; set; }

        [Newtonsoft.Json.JsonConverter(typeof(StringEnumConverter)), BsonRepresentation(BsonType.String), BsonElement("lane")]
        [JsonPropertyName("lane")]
        public Lane Lane { get; set; }
    }
}
