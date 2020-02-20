using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json.Converters;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace lol.stats.api.Dtos
{
    public class MatchDetail
    {
        [BsonId]
        [JsonPropertyName("gameId")]
        public long GameId { get; set; }

        [Newtonsoft.Json.JsonConverter(typeof(StringEnumConverter)), BsonRepresentation(BsonType.String), BsonElement("platformId")]
        [JsonPropertyName("platformId")]
        public PlatformId PlatformId { get; set; }

        [BsonElement("gameCreation")]
        [JsonPropertyName("gameCreation")]
        public long GameCreation { get; set; }

        [BsonElement("gameDuration")]
        [JsonPropertyName("gameDuration")]
        public long GameDuration { get; set; }

        [BsonElement("queueId")]
        [JsonPropertyName("queueId")]
        public long QueueId { get; set; }

        [BsonElement("mapId")]
        [JsonPropertyName("mapId")]
        public long MapId { get; set; }

        [BsonElement("seasonId")]
        [JsonPropertyName("seasonId")]
        public long SeasonId { get; set; }

        [BsonElement("gameVersion")]
        [JsonPropertyName("gameVersion")]
        public string GameVersion { get; set; }

        [BsonElement("gameMode")]
        [JsonPropertyName("gameMode")]
        public string GameMode { get; set; }

        [BsonElement("gameType")]
        [JsonPropertyName("gameType")]
        public string GameType { get; set; }

        [BsonElement("teams")]
        [JsonPropertyName("teams")]
        public List<Team> Teams { get; set; }

        [BsonElement("participants")]
        [JsonPropertyName("participants")]
        public List<Participant> Participants { get; set; }

        [BsonElement("participantIdentities")]
        [JsonPropertyName("participantIdentities")]
        public List<ParticipantIdentity> ParticipantIdentities { get; set; }
    }
}
