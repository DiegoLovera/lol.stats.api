using lol.stats.api.Dtos;
using lol.stats.api.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace lol.stats.api.Business
{
    public class SummonerStatsBusiness : ISummonerStatsBusiness
    {
        private readonly IRiotService _riotService;
        private readonly int _maxMatchesPerRequest = 5;
        private readonly int[] validQueues = { 400, 420, 430, 440 };

        public SummonerStatsBusiness(IRiotService riotService)
        {
            _riotService = riotService;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="summonerName"></param>
        /// <param name="page"></param>
        /// <param name="queues"></param>
        /// <param name="seasons"></param>
        /// <returns></returns>
        public async Task<List<MatchDetail>> GetSummonerMatchesAsync(string summonerName, int page, int[] queues, int[] seasons)
        {
            // In case of not sending any queue all valid queues are used.
            queues = (queues.Length == 0 ? validQueues : queues);

            var summonerData = await _riotService.GetSummoner(summonerName);
            int beginIndex = page;
            int endIndex = page * _maxMatchesPerRequest;
            if (beginIndex == 1)
            {
                endIndex = _maxMatchesPerRequest;
                beginIndex = 0;
            }
            else
            {
                endIndex = page * _maxMatchesPerRequest;
                beginIndex = endIndex - _maxMatchesPerRequest;
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
                            summonerMatches = await _riotService.GetSummonerMatches(summonerData.AccountId, queue, 13, 1578668400000, beginIndex, endIndex);
                        }
                        else
                        {
                            summonerMatches = await _riotService.GetSummonerMatches(summonerData.AccountId, queue, season, beginIndex, endIndex);
                        }
                        result.Matches.AddRange(summonerMatches.Matches);
                        result.TotalGames += summonerMatches.TotalGames;
                    }
                }
                else
                {
                    MatchesList summonerMatches = await _riotService.GetSummonerMatches(queue, summonerData.AccountId, beginIndex, endIndex);
                    result.Matches.AddRange(summonerMatches.Matches);
                    result.TotalGames += summonerMatches.TotalGames;
                }
            }
            result.Matches = new List<Match>(result.Matches.OrderByDescending(c => c.Timestamp));
            return await GetMatchDetailsListAsync(result);
        }

        private async Task<List<MatchDetail>> GetMatchDetailsListAsync(MatchesList matchesList)
        {
            var result = new List<MatchDetail>();
            long matchId = 0L;
            try
            {
                foreach (Match match in matchesList.Matches)
                {
                    matchId = match.GameId;
                    result.Add(await _riotService.GetMatchDetail(match.GameId));
                }
            }
            catch(Exception ex)
            {
                matchId.ToString();
                ex.ToString();
            }
            return result;
        }
    }
}
