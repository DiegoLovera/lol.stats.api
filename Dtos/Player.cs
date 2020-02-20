using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json.Converters;
using System.Text.Json.Serialization;

namespace lol.stats.api.Dtos
{
    public class Player
    {
        [Newtonsoft.Json.JsonConverter(typeof(StringEnumConverter)), BsonRepresentation(BsonType.String), BsonElement("platformId")]
        [JsonPropertyName("platformId")]
        public PlatformId PlatformId { get; set; }

        [BsonElement("accountId")]
        [JsonPropertyName("accountId")]
        public string AccountId { get; set; }

        [BsonElement("summonerName")]
        [JsonPropertyName("summonerName")]
        public string SummonerName { get; set; }

        [BsonElement("summonerId")]
        [JsonPropertyName("summonerId")]
        public string SummonerId { get; set; }

        [Newtonsoft.Json.JsonConverter(typeof(StringEnumConverter)), BsonRepresentation(BsonType.String), BsonElement("currentPlatformId")]
        [JsonPropertyName("currentPlatformId")]
        public PlatformId CurrentPlatformId { get; set; }

        [BsonElement("currentAccountId")]
        [JsonPropertyName("currentAccountId")]
        public string CurrentAccountId { get; set; }

        [BsonElement("matchHistoryUri")]
        [JsonPropertyName("matchHistoryUri")]
        public string MatchHistoryUri { get; set; }

        [BsonElement("profileIcon")]
        [JsonPropertyName("profileIcon")]
        public long ProfileIcon { get; set; }
    }
}
