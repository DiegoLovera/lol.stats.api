namespace lol.stats.api.Dtos
{
    public class Premade
    {
        public string SummonerName { get; set; }
        public long Wins { get; set; }
        public long Losses { get; set; }
        public long Games => Wins + Losses;
        public float WinRate => Wins / Games;
    }
}
