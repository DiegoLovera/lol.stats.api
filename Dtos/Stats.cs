using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace lol.stats.api.Dtos
{
    public class Stats
    {
        [JsonPropertyName("participantId")]
        public long ParticipantId { get; set; }

        [JsonPropertyName("win")]
        public bool Win { get; set; }

        [JsonPropertyName("item0")]
        public long Item0 { get; set; }

        [JsonPropertyName("item1")]
        public long Item1 { get; set; }

        [JsonPropertyName("item2")]
        public long Item2 { get; set; }

        [JsonPropertyName("item3")]
        public long Item3 { get; set; }

        [JsonPropertyName("item4")]
        public long Item4 { get; set; }

        [JsonPropertyName("item5")]
        public long Item5 { get; set; }

        [JsonPropertyName("item6")]
        public long Item6 { get; set; }

        [JsonPropertyName("kills")]
        public long Kills { get; set; }

        [JsonPropertyName("deaths")]
        public long Deaths { get; set; }

        [JsonPropertyName("assists")]
        public long Assists { get; set; }

        [JsonPropertyName("largestKillingSpree")]
        public long LargestKillingSpree { get; set; }

        [JsonPropertyName("largestMultiKill")]
        public long LargestMultiKill { get; set; }

        [JsonPropertyName("killingSprees")]
        public long KillingSprees { get; set; }

        [JsonPropertyName("longestTimeSpentLiving")]
        public long LongestTimeSpentLiving { get; set; }

        [JsonPropertyName("doubleKills")]
        public long DoubleKills { get; set; }

        [JsonPropertyName("tripleKills")]
        public long TripleKills { get; set; }

        [JsonPropertyName("quadraKills")]
        public long QuadraKills { get; set; }

        [JsonPropertyName("pentaKills")]
        public long PentaKills { get; set; }

        [JsonPropertyName("unrealKills")]
        public long UnrealKills { get; set; }

        [JsonPropertyName("totalDamageDealt")]
        public long TotalDamageDealt { get; set; }

        [JsonPropertyName("magicDamageDealt")]
        public long MagicDamageDealt { get; set; }

        [JsonPropertyName("physicalDamageDealt")]
        public long PhysicalDamageDealt { get; set; }

        [JsonPropertyName("trueDamageDealt")]
        public long TrueDamageDealt { get; set; }

        [JsonPropertyName("largestCriticalStrike")]
        public long LargestCriticalStrike { get; set; }

        [JsonPropertyName("totalDamageDealtToChampions")]
        public long TotalDamageDealtToChampions { get; set; }

        [JsonPropertyName("magicDamageDealtToChampions")]
        public long MagicDamageDealtToChampions { get; set; }

        [JsonPropertyName("physicalDamageDealtToChampions")]
        public long PhysicalDamageDealtToChampions { get; set; }

        [JsonPropertyName("trueDamageDealtToChampions")]
        public long TrueDamageDealtToChampions { get; set; }

        [JsonPropertyName("totalHeal")]
        public long TotalHeal { get; set; }

        [JsonPropertyName("totalUnitsHealed")]
        public long TotalUnitsHealed { get; set; }

        [JsonPropertyName("damageSelfMitigated")]
        public long DamageSelfMitigated { get; set; }

        [JsonPropertyName("damageDealtToObjectives")]
        public long DamageDealtToObjectives { get; set; }

        [JsonPropertyName("damageDealtToTurrets")]
        public long DamageDealtToTurrets { get; set; }

        [JsonPropertyName("visionScore")]
        public long VisionScore { get; set; }

        [JsonPropertyName("timeCCingOthers")]
        public long TimeCCingOthers { get; set; }

        [JsonPropertyName("totalDamageTaken")]
        public long TotalDamageTaken { get; set; }

        [JsonPropertyName("magicalDamageTaken")]
        public long MagicalDamageTaken { get; set; }

        [JsonPropertyName("physicalDamageTaken")]
        public long PhysicalDamageTaken { get; set; }

        [JsonPropertyName("trueDamageTaken")]
        public long TrueDamageTaken { get; set; }

        [JsonPropertyName("goldEarned")]
        public long GoldEarned { get; set; }

        [JsonPropertyName("goldSpent")]
        public long GoldSpent { get; set; }

        [JsonPropertyName("turretKills")]
        public long TurretKills { get; set; }

        [JsonPropertyName("inhibitorKills")]
        public long InhibitorKills { get; set; }

        [JsonPropertyName("totalMinionsKilled")]
        public long TotalMinionsKilled { get; set; }

        [JsonPropertyName("neutralMinionsKilled")]
        public long NeutralMinionsKilled { get; set; }

        [JsonPropertyName("neutralMinionsKilledTeamJungle")]
        public long NeutralMinionsKilledTeamJungle { get; set; }

        [JsonPropertyName("neutralMinionsKilledEnemyJungle")]
        public long NeutralMinionsKilledEnemyJungle { get; set; }

        [JsonPropertyName("totalTimeCrowdControlDealt")]
        public long TotalTimeCrowdControlDealt { get; set; }

        [JsonPropertyName("champLevel")]
        public long ChampLevel { get; set; }

        [JsonPropertyName("visionWardsBoughtInGame")]
        public long VisionWardsBoughtInGame { get; set; }

        [JsonPropertyName("sightWardsBoughtInGame")]
        public long SightWardsBoughtInGame { get; set; }

        [JsonPropertyName("wardsPlaced")]
        public long WardsPlaced { get; set; }

        [JsonPropertyName("wardsKilled")]
        public long WardsKilled { get; set; }

        [JsonPropertyName("firstBloodKill")]
        public bool FirstBloodKill { get; set; }

        [JsonPropertyName("firstBloodAssist")]
        public bool FirstBloodAssist { get; set; }

        [JsonPropertyName("firstTowerKill")]
        public bool FirstTowerKill { get; set; }

        [JsonPropertyName("firstTowerAssist")]
        public bool FirstTowerAssist { get; set; }

        [JsonPropertyName("firstInhibitorKill")]
        public bool FirstInhibitorKill { get; set; }

        [JsonPropertyName("firstInhibitorAssist")]
        public bool FirstInhibitorAssist { get; set; }

        [JsonPropertyName("combatPlayerScore")]
        public long CombatPlayerScore { get; set; }

        [JsonPropertyName("objectivePlayerScore")]
        public long ObjectivePlayerScore { get; set; }

        [JsonPropertyName("totalPlayerScore")]
        public long TotalPlayerScore { get; set; }

        [JsonPropertyName("totalScoreRank")]
        public long TotalScoreRank { get; set; }

        [JsonPropertyName("playerScore0")]
        public long PlayerScore0 { get; set; }

        [JsonPropertyName("playerScore1")]
        public long PlayerScore1 { get; set; }

        [JsonPropertyName("playerScore2")]
        public long PlayerScore2 { get; set; }

        [JsonPropertyName("playerScore3")]
        public long PlayerScore3 { get; set; }

        [JsonPropertyName("playerScore4")]
        public long PlayerScore4 { get; set; }

        [JsonPropertyName("playerScore5")]
        public long PlayerScore5 { get; set; }

        [JsonPropertyName("playerScore6")]
        public long PlayerScore6 { get; set; }

        [JsonPropertyName("playerScore7")]
        public long PlayerScore7 { get; set; }

        [JsonPropertyName("playerScore8")]
        public long PlayerScore8 { get; set; }

        [JsonPropertyName("playerScore9")]
        public long PlayerScore9 { get; set; }

        [JsonPropertyName("perk0")]
        public long Perk0 { get; set; }

        [JsonPropertyName("perk0Var1")]
        public long Perk0Var1 { get; set; }

        [JsonPropertyName("perk0Var2")]
        public long Perk0Var2 { get; set; }

        [JsonPropertyName("perk0Var3")]
        public long Perk0Var3 { get; set; }

        [JsonPropertyName("perk1")]
        public long Perk1 { get; set; }

        [JsonPropertyName("perk1Var1")]
        public long Perk1Var1 { get; set; }

        [JsonPropertyName("perk1Var2")]
        public long Perk1Var2 { get; set; }

        [JsonPropertyName("perk1Var3")]
        public long Perk1Var3 { get; set; }

        [JsonPropertyName("perk2")]
        public long Perk2 { get; set; }

        [JsonPropertyName("perk2Var1")]
        public long Perk2Var1 { get; set; }

        [JsonPropertyName("perk2Var2")]
        public long Perk2Var2 { get; set; }

        [JsonPropertyName("perk2Var3")]
        public long Perk2Var3 { get; set; }

        [JsonPropertyName("perk3")]
        public long Perk3 { get; set; }

        [JsonPropertyName("perk3Var1")]
        public long Perk3Var1 { get; set; }

        [JsonPropertyName("perk3Var2")]
        public long Perk3Var2 { get; set; }

        [JsonPropertyName("perk3Var3")]
        public long Perk3Var3 { get; set; }

        [JsonPropertyName("perk4")]
        public long Perk4 { get; set; }

        [JsonPropertyName("perk4Var1")]
        public long Perk4Var1 { get; set; }

        [JsonPropertyName("perk4Var2")]
        public long Perk4Var2 { get; set; }

        [JsonPropertyName("perk4Var3")]
        public long Perk4Var3 { get; set; }

        [JsonPropertyName("perk5")]
        public long Perk5 { get; set; }

        [JsonPropertyName("perk5Var1")]
        public long Perk5Var1 { get; set; }

        [JsonPropertyName("perk5Var2")]
        public long Perk5Var2 { get; set; }

        [JsonPropertyName("perk5Var3")]
        public long Perk5Var3 { get; set; }

        [JsonPropertyName("perkPrimaryStyle")]
        public long PerkPrimaryStyle { get; set; }

        [JsonPropertyName("perkSubStyle")]
        public long PerkSubStyle { get; set; }

        [JsonPropertyName("statPerk0")]
        public long StatPerk0 { get; set; }

        [JsonPropertyName("statPerk1")]
        public long StatPerk1 { get; set; }

        [JsonPropertyName("statPerk2")]
        public long StatPerk2 { get; set; }
    }
}
