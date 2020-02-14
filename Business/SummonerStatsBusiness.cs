using lol.stats.api.Dtos;
using lol.stats.api.Services;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace lol.stats.api.Business
{
    public class SummonerStatsBusiness : ISummonerStatsBusiness
    {
        private readonly IRiotService _riotService;

        public SummonerStatsBusiness(IRiotService riotService)
        {
            _riotService = riotService;
        }

        public async Task<MatchesList> GetSummonerMatchesAsync(string summonerName, int page, int[] queues, int[] seasons)
        {
            var summonerData = await _riotService.GetSummoner(summonerName);
            int beginIndex = page;
            int endIndex = page * 100;
            if (beginIndex == 1)
            {
                endIndex = 100;
                beginIndex = 0;
            }
            else
            {
                endIndex = page * 100;
                beginIndex = endIndex - 100;
            }

            var result = new MatchesList
            {
                Matches = new List<Match>()
            };
            foreach (int queue in queues)
            {
                if (seasons.Length > 0)
                {
                    foreach (int season in seasons)
                    {
                        MatchesList summonerMatches;
                        if (season == 14)
                        {
                            summonerMatches = await _riotService.GetSummonerMatches(summonerData.AccountId, queue, 13, 1578668400000);
                        }
                        else
                        {
                            summonerMatches = await _riotService.GetSummonerMatches(summonerData.AccountId, queue, season);
                        }
                        result.Matches.AddRange(summonerMatches.Matches);
                        result.TotalGames += summonerMatches.TotalGames;
                    }
                }
                else
                {
                    MatchesList summonerMatches = await _riotService.GetSummonerMatches(summonerData.AccountId, queue);
                    result.Matches.AddRange(summonerMatches.Matches);
                    result.TotalGames += summonerMatches.TotalGames;
                }
            }
            result.Matches = new List<Match>(result.Matches.OrderByDescending(c => c.Timestamp));
            return result;
        }
    }
}
