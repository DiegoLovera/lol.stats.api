using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace lol.stats.api.Dtos
{
    public class SummonerMatch
    {
        [JsonPropertyName("gameId")]
        public long GameId { get; set; }

        [Newtonsoft.Json.JsonConverter(typeof(StringEnumConverter))]
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

        [JsonPropertyName("alliedTeam")]
        public Team AlliedTeam { get; set; }

        [JsonPropertyName("enemyTeam")]
        public Team EnemyTeam { get; set; }

        [JsonPropertyName("currentParticipant")]
        public SummonerParticipant CurrentParticipant { get; set; }

        [JsonPropertyName("allies")]
        public List<SummonerParticipant> Allies { get; set; }

        [JsonPropertyName("enemies")]
        public List<SummonerParticipant> Enemies { get; set; }
    }
}
