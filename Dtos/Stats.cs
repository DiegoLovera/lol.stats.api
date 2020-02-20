using MongoDB.Bson.Serialization.Attributes;
using System.Text.Json.Serialization;

namespace lol.stats.api.Dtos
{
    public class Stats
    {
        [BsonElement("participantId")]
        [JsonPropertyName("participantId")]
        public long ParticipantId { get; set; }

        [BsonElement("win")]
        [JsonPropertyName("win")]
        public bool Win { get; set; }

        [BsonElement("item0")]
        [JsonPropertyName("item0")]
        public long Item0 { get; set; }

        [BsonElement("item1")]
        [JsonPropertyName("item1")]
        public long Item1 { get; set; }

        [BsonElement("item2")]
        [JsonPropertyName("item2")]
        public long Item2 { get; set; }

        [BsonElement("item3")]
        [JsonPropertyName("item3")]
        public long Item3 { get; set; }

        [BsonElement("item4")]
        [JsonPropertyName("item4")]
        public long Item4 { get; set; }

        [BsonElement("item5")]
        [JsonPropertyName("item5")]
        public long Item5 { get; set; }

        [BsonElement("item6")]
        [JsonPropertyName("item6")]
        public long Item6 { get; set; }

        [BsonElement("kills")]
        [JsonPropertyName("kills")]
        public long Kills { get; set; }

        [BsonElement("deaths")]
        [JsonPropertyName("deaths")]
        public long Deaths { get; set; }

        [BsonElement("assists")]
        [JsonPropertyName("assists")]
        public long Assists { get; set; }

        [BsonElement("largestKillingSpree")]
        [JsonPropertyName("largestKillingSpree")]
        public long LargestKillingSpree { get; set; }

        [BsonElement("largestMultiKill")]
        [JsonPropertyName("largestMultiKill")]
        public long LargestMultiKill { get; set; }

        [BsonElement("killingSprees")]
        [JsonPropertyName("killingSprees")]
        public long KillingSprees { get; set; }

        [BsonElement("longestTimeSpentLiving")]
        [JsonPropertyName("longestTimeSpentLiving")]
        public long LongestTimeSpentLiving { get; set; }

        [BsonElement("doubleKills")]
        [JsonPropertyName("doubleKills")]
        public long DoubleKills { get; set; }

        [BsonElement("tripleKills")]
        [JsonPropertyName("tripleKills")]
        public long TripleKills { get; set; }

        [BsonElement("quadraKills")]
        [JsonPropertyName("quadraKills")]
        public long QuadraKills { get; set; }

        [BsonElement("pentaKills")]
        [JsonPropertyName("pentaKills")]
        public long PentaKills { get; set; }

        [BsonElement("unrealKills")]
        [JsonPropertyName("unrealKills")]
        public long UnrealKills { get; set; }

        [BsonElement("totalDamageDealt")]
        [JsonPropertyName("totalDamageDealt")]
        public long TotalDamageDealt { get; set; }

        [BsonElement("magicDamageDealt")]
        [JsonPropertyName("magicDamageDealt")]
        public long MagicDamageDealt { get; set; }

        [BsonElement("physicalDamageDealt")]
        [JsonPropertyName("physicalDamageDealt")]
        public long PhysicalDamageDealt { get; set; }

        [BsonElement("trueDamageDealt")]
        [JsonPropertyName("trueDamageDealt")]
        public long TrueDamageDealt { get; set; }

        [BsonElement("largestCriticalStrike")]
        [JsonPropertyName("largestCriticalStrike")]
        public long LargestCriticalStrike { get; set; }

        [BsonElement("totalDamageDealtToChampions")]
        [JsonPropertyName("totalDamageDealtToChampions")]
        public long TotalDamageDealtToChampions { get; set; }

        [BsonElement("magicDamageDealtToChampions")]
        [JsonPropertyName("magicDamageDealtToChampions")]
        public long MagicDamageDealtToChampions { get; set; }

        [BsonElement("physicalDamageDealtToChampions")]
        [JsonPropertyName("physicalDamageDealtToChampions")]
        public long PhysicalDamageDealtToChampions { get; set; }

        [BsonElement("trueDamageDealtToChampions")]
        [JsonPropertyName("trueDamageDealtToChampions")]
        public long TrueDamageDealtToChampions { get; set; }

        [BsonElement("totalHeal")]
        [JsonPropertyName("totalHeal")]
        public long TotalHeal { get; set; }

        [BsonElement("totalUnitsHealed")]
        [JsonPropertyName("totalUnitsHealed")]
        public long TotalUnitsHealed { get; set; }

        [BsonElement("damageSelfMitigated")]
        [JsonPropertyName("damageSelfMitigated")]
        public long DamageSelfMitigated { get; set; }

        [BsonElement("damageDealtToObjectives")]
        [JsonPropertyName("damageDealtToObjectives")]
        public long DamageDealtToObjectives { get; set; }

        [BsonElement("damageDealtToTurrets")]
        [JsonPropertyName("damageDealtToTurrets")]
        public long DamageDealtToTurrets { get; set; }

        [BsonElement("visionScore")]
        [JsonPropertyName("visionScore")]
        public long VisionScore { get; set; }

        [BsonElement("timeCCingOthers")]
        [JsonPropertyName("timeCCingOthers")]
        public long TimeCCingOthers { get; set; }

        [BsonElement("totalDamageTaken")]
        [JsonPropertyName("totalDamageTaken")]
        public long TotalDamageTaken { get; set; }

        [BsonElement("magicalDamageTaken")]
        [JsonPropertyName("magicalDamageTaken")]
        public long MagicalDamageTaken { get; set; }

        [BsonElement("physicalDamageTaken")]
        [JsonPropertyName("physicalDamageTaken")]
        public long PhysicalDamageTaken { get; set; }

        [BsonElement("trueDamageTaken")]
        [JsonPropertyName("trueDamageTaken")]
        public long TrueDamageTaken { get; set; }

        [BsonElement("goldEarned")]
        [JsonPropertyName("goldEarned")]
        public long GoldEarned { get; set; }

        [BsonElement("goldSpent")]
        [JsonPropertyName("goldSpent")]
        public long GoldSpent { get; set; }

        [BsonElement("turretKills")]
        [JsonPropertyName("turretKills")]
        public long TurretKills { get; set; }

        [BsonElement("inhibitorKills")]
        [JsonPropertyName("inhibitorKills")]
        public long InhibitorKills { get; set; }

        [BsonElement("totalMinionsKilled")]
        [JsonPropertyName("totalMinionsKilled")]
        public long TotalMinionsKilled { get; set; }

        [BsonElement("neutralMinionsKilled")]
        [JsonPropertyName("neutralMinionsKilled")]
        public long NeutralMinionsKilled { get; set; }

        [BsonElement("neutralMinionsKilledTeamJungle")]
        [JsonPropertyName("neutralMinionsKilledTeamJungle")]
        public long NeutralMinionsKilledTeamJungle { get; set; }

        [BsonElement("neutralMinionsKilledEnemyJungle")]
        [JsonPropertyName("neutralMinionsKilledEnemyJungle")]
        public long NeutralMinionsKilledEnemyJungle { get; set; }

        [BsonElement("totalTimeCrowdControlDealt")]
        [JsonPropertyName("totalTimeCrowdControlDealt")]
        public long TotalTimeCrowdControlDealt { get; set; }

        [BsonElement("champLevel")]
        [JsonPropertyName("champLevel")]
        public long ChampLevel { get; set; }

        [BsonElement("visionWardsBoughtInGame")]
        [JsonPropertyName("visionWardsBoughtInGame")]
        public long VisionWardsBoughtInGame { get; set; }

        [BsonElement("sightWardsBoughtInGame")]
        [JsonPropertyName("sightWardsBoughtInGame")]
        public long SightWardsBoughtInGame { get; set; }

        [BsonElement("wardsPlaced")]
        [JsonPropertyName("wardsPlaced")]
        public long WardsPlaced { get; set; }

        [BsonElement("wardsKilled")]
        [JsonPropertyName("wardsKilled")]
        public long WardsKilled { get; set; }

        [BsonElement("firstBloodKill")]
        [JsonPropertyName("firstBloodKill")]
        public bool FirstBloodKill { get; set; }

        [BsonElement("firstBloodAssist")]
        [JsonPropertyName("firstBloodAssist")]
        public bool FirstBloodAssist { get; set; }

        [BsonElement("firstTowerKill")]
        [JsonPropertyName("firstTowerKill")]
        public bool FirstTowerKill { get; set; }

        [BsonElement("firstTowerAssist")]
        [JsonPropertyName("firstTowerAssist")]
        public bool FirstTowerAssist { get; set; }

        [BsonElement("firstInhibitorKill")]
        [JsonPropertyName("firstInhibitorKill")]
        public bool FirstInhibitorKill { get; set; }

        [BsonElement("firstInhibitorAssist")]
        [JsonPropertyName("firstInhibitorAssist")]
        public bool FirstInhibitorAssist { get; set; }
        
        [BsonElement("combatPlayerScore")]
        [JsonPropertyName("combatPlayerScore")]
        public long CombatPlayerScore { get; set; }

        [BsonElement("objectivePlayerScore")]
        [JsonPropertyName("objectivePlayerScore")]
        public long ObjectivePlayerScore { get; set; }

        [BsonElement("totalPlayerScore")]
        [JsonPropertyName("totalPlayerScore")]
        public long TotalPlayerScore { get; set; }

        [BsonElement("totalScoreRank")]
        [JsonPropertyName("totalScoreRank")]
        public long TotalScoreRank { get; set; }

        [BsonElement("playerScore0")]
        [JsonPropertyName("playerScore0")]
        public long PlayerScore0 { get; set; }

        [BsonElement("playerScore1")]
        [JsonPropertyName("playerScore1")]
        public long PlayerScore1 { get; set; }

        [BsonElement("playerScore2")]
        [JsonPropertyName("playerScore2")]
        public long PlayerScore2 { get; set; }

        [BsonElement("playerScore3")]
        [JsonPropertyName("playerScore3")]
        public long PlayerScore3 { get; set; }

        [BsonElement("playerScore4")]
        [JsonPropertyName("playerScore4")]
        public long PlayerScore4 { get; set; }

        [BsonElement("playerScore5")]
        [JsonPropertyName("playerScore5")]
        public long PlayerScore5 { get; set; }

        [BsonElement("playerScore6")]
        [JsonPropertyName("playerScore6")]
        public long PlayerScore6 { get; set; }

        [BsonElement("playerScore7")]
        [JsonPropertyName("playerScore7")]
        public long PlayerScore7 { get; set; }

        [BsonElement("playerScore8")]
        [JsonPropertyName("playerScore8")]
        public long PlayerScore8 { get; set; }

        [BsonElement("playerScore9")]
        [JsonPropertyName("playerScore9")]
        public long PlayerScore9 { get; set; }

        [BsonElement("perk0")]
        [JsonPropertyName("perk0")]
        public long Perk0 { get; set; }

        [BsonElement("perk0Var1")]
        [JsonPropertyName("perk0Var1")]
        public long Perk0Var1 { get; set; }

        [BsonElement("perk0Var2")]
        [JsonPropertyName("perk0Var2")]
        public long Perk0Var2 { get; set; }

        [BsonElement("perk0Var3")]
        [JsonPropertyName("perk0Var3")]
        public long Perk0Var3 { get; set; }

        [BsonElement("perk1")]
        [JsonPropertyName("perk1")]
        public long Perk1 { get; set; }

        [BsonElement("perk1Var1")]
        [JsonPropertyName("perk1Var1")]
        public long Perk1Var1 { get; set; }

        [BsonElement("perk1Var2")]
        [JsonPropertyName("perk1Var2")]
        public long Perk1Var2 { get; set; }

        [BsonElement("perk1Var3")]
        [JsonPropertyName("perk1Var3")]
        public long Perk1Var3 { get; set; }

        [BsonElement("perk2")]
        [JsonPropertyName("perk2")]
        public long Perk2 { get; set; }

        [BsonElement("perk2Var1")]
        [JsonPropertyName("perk2Var1")]
        public long Perk2Var1 { get; set; }

        [BsonElement("perk2Var2")]
        [JsonPropertyName("perk2Var2")]
        public long Perk2Var2 { get; set; }

        [BsonElement("perk2Var3")]
        [JsonPropertyName("perk2Var3")]
        public long Perk2Var3 { get; set; }

        [BsonElement("perk3")]
        [JsonPropertyName("perk3")]
        public long Perk3 { get; set; }

        [BsonElement("perk3Var1")]
        [JsonPropertyName("perk3Var1")]
        public long Perk3Var1 { get; set; }

        [BsonElement("perk3Var2")]
        [JsonPropertyName("perk3Var2")]
        public long Perk3Var2 { get; set; }

        [BsonElement("perk3Var3")]
        [JsonPropertyName("perk3Var3")]
        public long Perk3Var3 { get; set; }

        [BsonElement("cost")]
        [JsonPropertyName("perk4")]
        public long Perk4 { get; set; }

        [BsonElement("perk4Var1")]
        [JsonPropertyName("perk4Var1")]
        public long Perk4Var1 { get; set; }

        [BsonElement("perk4Var2")]
        [JsonPropertyName("perk4Var2")]
        public long Perk4Var2 { get; set; }

        [BsonElement("perk4Var3")]
        [JsonPropertyName("perk4Var3")]
        public long Perk4Var3 { get; set; }

        [BsonElement("perk5")]
        [JsonPropertyName("perk5")]
        public long Perk5 { get; set; }

        [BsonElement("perk5Var1")]
        [JsonPropertyName("perk5Var1")]
        public long Perk5Var1 { get; set; }

        [BsonElement("perk5Var2")]
        [JsonPropertyName("perk5Var2")]
        public long Perk5Var2 { get; set; }

        [BsonElement("perk5Var3")]
        [JsonPropertyName("perk5Var3")]
        public long Perk5Var3 { get; set; }

        [BsonElement("perkPrimaryStyle")]
        [JsonPropertyName("perkPrimaryStyle")]
        public long PerkPrimaryStyle { get; set; }

        [BsonElement("perkSubStyle")]
        [JsonPropertyName("perkSubStyle")]
        public long PerkSubStyle { get; set; }

        [BsonElement("statPerk0")]
        [JsonPropertyName("statPerk0")]
        public long StatPerk0 { get; set; }

        [BsonElement("statPerk1")]
        [JsonPropertyName("statPerk1")]
        public long StatPerk1 { get; set; }

        [BsonElement("statPerk2")]
        [JsonPropertyName("statPerk2")]
        public long StatPerk2 { get; set; }
    }
}
