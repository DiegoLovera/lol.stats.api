using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace lol.stats.api.Dtos
{
    public class MatchDetail
    {
        [JsonPropertyName("gameId")]
        public long GameId { get; set; }

        [JsonPropertyName("platformId")]
        public PlatformId PlatformId { get; set; }

        [JsonPropertyName("gameCreation")]
        public long GameCreation { get; set; }

        [JsonPropertyName("gameDuration")]
        public long GameDuration { get; set; }

        [JsonPropertyName("queueId")]
        public long QueueId { get; set; }

        [JsonPropertyName("mapId")]
        public long MapId { get; set; }

        [JsonPropertyName("seasonId")]
        public long SeasonId { get; set; }

        [JsonPropertyName("gameVersion")]
        public string GameVersion { get; set; }

        [JsonPropertyName("gameMode")]
        public string GameMode { get; set; }

        [JsonPropertyName("gameType")]
        public string GameType { get; set; }

        [JsonPropertyName("teams")]
        public List<Team> Teams { get; set; }

        [JsonPropertyName("participants")]
        public List<Participant> Participants { get; set; }

        [JsonPropertyName("participantIdentities")]
        public List<ParticipantIdentity> ParticipantIdentities { get; set; }
    }
}
