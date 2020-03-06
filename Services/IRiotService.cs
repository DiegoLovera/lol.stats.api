using lol.stats.api.Dtos;
using lol.stats.api.Dtos.Riot;
using System.Threading.Tasks;

namespace lol.stats.api.Services
{
    public interface IRiotService
    {
        Task<Summoner> GetSummoner(string summonerName);
        Task<MatchesList> GetSummonerMatches(string accountId, int queue, int season, long beginTime, int beginIndex, int endIndex);
        Task<MatchesList> GetSummonerMatches(string accountId, int season, long beginTime, int beginIndex, int endIndex);
        Task<MatchesList> GetSummonerMatches(string accountId, int queue, int season, int beginIndex, int endIndex);
        Task<MatchesList> GetSummonerMatches(string accountId, int season, int beginIndex, int endIndex);
        Task<MatchesList> GetSummonerMatches(int queue, string accountId, int beginIndex, int endIndex);
        Task<MatchesList> GetSummonerMatches(string accountId, int beginIndex, int endIndex);
        Task<MatchDetail> GetMatchDetail(long matchId);
        Task<Champions> GetChampions();
    }
}
