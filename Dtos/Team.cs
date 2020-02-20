using MongoDB.Bson.Serialization.Attributes;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace lol.stats.api.Dtos
{
    public class Team
    {
        [BsonElement("teamId")]
        [JsonPropertyName("teamId")]
        public long TeamId { get; set; }

        [BsonElement("win")]
        [JsonPropertyName("win")]
        public string Win { get; set; }

        [BsonElement("firstBlood")]
        [JsonPropertyName("firstBlood")]
        public bool FirstBlood { get; set; }

        [BsonElement("firstTower")]
        [JsonPropertyName("firstTower")]
        public bool FirstTower { get; set; }

        [BsonElement("firstInhibitor")]
        [JsonPropertyName("firstInhibitor")]
        public bool FirstInhibitor { get; set; }

        [BsonElement("firstBaron")]
        [JsonPropertyName("firstBaron")]
        public bool FirstBaron { get; set; }

        [BsonElement("firstDragon")]
        [JsonPropertyName("firstDragon")]
        public bool FirstDragon { get; set; }

        [BsonElement("firstRiftHerald")]
        [JsonPropertyName("firstRiftHerald")]
        public bool FirstRiftHerald { get; set; }

        [BsonElement("towerKills")]
        [JsonPropertyName("towerKills")]
        public long TowerKills { get; set; }

        [BsonElement("inhibitorKills")]
        [JsonPropertyName("inhibitorKills")]
        public long InhibitorKills { get; set; }

        [BsonElement("baronKills")]
        [JsonPropertyName("baronKills")]
        public long BaronKills { get; set; }

        [BsonElement("dragonKills")]
        [JsonPropertyName("dragonKills")]
        public long DragonKills { get; set; }

        [BsonElement("vilemawKills")]
        [JsonPropertyName("vilemawKills")]
        public long VilemawKills { get; set; }

        [BsonElement("riftHeraldKills")]
        [JsonPropertyName("riftHeraldKills")]
        public long RiftHeraldKills { get; set; }

        [BsonElement("dominionVictoryScore")]
        [JsonPropertyName("dominionVictoryScore")]
        public long DominionVictoryScore { get; set; }

        [BsonElement("bans")]
        [JsonPropertyName("bans")]
        public List<Ban> Bans { get; set; }
    }
}
