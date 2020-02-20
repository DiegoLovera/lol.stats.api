namespace lol.stats.api.Dtos
{
    public class UniqueChampionStats
    {
        public long ChampionId { get; set; }

        public long Kills { get; set; }
        public long Deaths { get; set; }
        public long Assists { get; set; }
        public double Kda => ((double)(Kills + Assists)) / (Deaths > 0 ? Deaths : 1);

        public long MaxKills { get; set; }
        public long MaxDeaths { get; set; }
        public long MaxAssists { get; set; }

        public double AverageKills => ((double)Kills) / Games;
        public double AverageDeaths => ((double)Deaths) / Games;
        public double AverageAssists => ((double)Assists) / Games;

        public long Wins { get; set; }
        public long Losses { get; set; }
        public long Games => Wins + Losses;
        public double WinRate => ((double)Wins) / (Games > 0 ? Games : 1);
    }
}
