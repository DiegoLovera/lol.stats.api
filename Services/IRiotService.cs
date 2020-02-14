using lol.stats.api.Dtos;
using System.Threading.Tasks;

namespace lol.stats.api.Services
{
    public interface IRiotService
    {
        Task<Summoner> GetSummoner(string summonerName);
        Task<SummonerMatches> GetSummonerMatches(string accountId, int queue, int season, long beginTime = 1578668400000);
        Task<MatchDetail> GetMatchDetail(string gameId);
    }
}
