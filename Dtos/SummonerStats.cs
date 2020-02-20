using System.Collections.Generic;

namespace lol.stats.api.Dtos
{
    public class SummonerStats
    {
        public double WinRate => ((double)Wins) / (Games > 0 ? Games : 1);
        public long Wins { get; set; }
        public long Losses { get; set; }
        public long Games => Wins + Losses;

        public double Kda => ((double)(Kills + Assists)) / (Deaths > 0 ? Deaths : 1);

        public long Kills { get; set; }
        public long Deaths { get; set; }
        public long Assists { get; set; }

        public long MaxKills { get; set; }
        public long MaxDeaths { get; set; }
        public long MaxAssists { get; set; }

        public double AverageKills => ((double)Kills) / (Games > 0 ? Games : 1);
        public double AverageDeaths => ((double)Deaths) / (Games > 0 ? Games : 1);
        public double AverageAssists => ((double)Assists) / (Games > 0 ? Games : 1);

        public List<UniqueChampionStats> UniqueChampions { get; set; }

        public double JungleWinRate => ((double)JungleWins) / (JungleGames > 0 ? JungleGames : 1);
        public long JungleWins { get; set; }
        public long JungleLosses { get; set; }
        public long JungleGames => JungleWins + JungleLosses;

        public double BottomCarryWinRate => ((double)BottomCarryWins) / (BottomCarryGames > 0 ? BottomCarryGames : 1);
        public long BottomCarryWins { get; set; }
        public long BottomCarryLosses { get; set; }
        public long BottomCarryGames => BottomCarryWins + BottomCarryLosses;

        public double BottomSupportWinRate => ((double)BottomSupportWins) / (BottomSupportGames > 0 ? BottomSupportGames : 1);
        public long BottomSupportWins { get; set; }
        public long BottomSupportLosses { get; set; }
        public long BottomSupportGames => BottomSupportWins + BottomSupportLosses;

        public double MidlaneCarryWinRate => ((double)MidlaneCarryWins) / (MidlaneCarryGames > 0 ? MidlaneCarryGames : 1);
        public long MidlaneCarryWins { get; set; }
        public long MidlaneCarryLosses { get; set; }
        public long MidlaneCarryGames => MidlaneCarryWins + MidlaneCarryLosses;

        public double TopCarryWinRate => ((double)TopCarryWins) / (TopCarryGames > 0 ? TopCarryGames : 1);
        public long TopCarryWins { get; set; }
        public long TopCarryLosses { get; set; }
        public long TopCarryGames => TopCarryWins + TopCarryLosses;

        public List<Premade> Premades { get; set; }

        public List<MatchDetail> MatchesDetails { get; set; }
    }
}
