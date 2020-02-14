using lol.stats.api.Dtos;
using System.Threading.Tasks;

namespace lol.stats.api.Services
{
    public interface IRiotService
    {
        Task<Summoner> GetSummoner(string summonerName);
        Task<SummonerMatches> GetSummonerMatches(string accountId, int queue, int season, long beginTime);
        Task<SummonerMatches> GetSummonerMatches(string accountId, int season, long beginTime);
        Task<SummonerMatches> GetSummonerMatches(string accountId, int queue, int season);
        Task<SummonerMatches> GetSummonerMatches(string accountId, int season);
        Task<SummonerMatches> GetSummonerMatches(string accountId);
        Task<MatchDetail> GetMatchDetail(string gameId);
    }
}
