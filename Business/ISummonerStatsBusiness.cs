using lol.stats.api.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace lol.stats.api.Business
{
    public interface ISummonerStatsBusiness
    {
        Task<SummonerStats> GetSummonerStatsAsync(string summonerName);
        Task<List<MatchDetail>> GetSummonerMatchesAsync(string summonerName, int page, int[] queues, int[] seasons);
        Task<List<MatchDetail>> GetSummonerMatchesAsync(string summonerName, int page, long[] queues);
        Task<int> LoadAllSummonerMatches(string summonerName, int[] queues);
    }
}
