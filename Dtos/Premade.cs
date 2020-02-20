namespace lol.stats.api.Dtos
{
    public class Premade
    {
        public string AccountId { get; set; }
        public string SummonerName { get; set; }
        public long Wins { get; set; }
        public long Losses { get; set; }
        public long Games => Wins + Losses;
        public double WinRate => ((double)Wins) / (Games > 0 ? Games : 1);
    }
}
