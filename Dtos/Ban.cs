using MongoDB.Bson.Serialization.Attributes;
using System.Text.Json.Serialization;

namespace lol.stats.api.Dtos
{
    public class Ban
    {
        [BsonElement("championId")]
        [JsonPropertyName("championId")]
        public long ChampionId { get; set; }

        [BsonElement("pickTurn")]
        [JsonPropertyName("pickTurn")]
        public long PickTurn { get; set; }
    }
}
