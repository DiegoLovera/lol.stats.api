using lol.stats.api.Dtos;
using lol.stats.api.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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

        public async Task<SummonerMatches> GetSummonerMatchesAsync(string summonerName, int[] queues, int[] seasons)
        {
            var summonerData = await _riotService.GetSummoner(summonerName);
            var result = new SummonerMatches
            {
                Matches = new List<Match>()
            };
            if (queues.Length > 0)
            {
                foreach (int queue in queues)
                {
                    if (seasons.Length > 0)
                    {
                        foreach (int season in seasons)
                        {
                            SummonerMatches summonerMatches;
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
                        SummonerMatches summonerMatches = await _riotService.GetSummonerMatches(summonerData.AccountId, queue);
                        result.Matches.AddRange(summonerMatches.Matches);
                        result.TotalGames += summonerMatches.TotalGames;
                    }
                }
            } 
            else
            {
                if (seasons.Length > 0)
                {
                    foreach (int season in seasons)
                    {
                        SummonerMatches summonerMatches;
                        if (season == 14)
                        {
                            summonerMatches = await _riotService.GetSummonerMatches(summonerData.AccountId, 13, 1578668400000);
                        }
                        else
                        {
                            summonerMatches = await _riotService.GetSummonerMatches(summonerData.AccountId, season);
                        }
                        result.Matches.AddRange(summonerMatches.Matches);
                        result.TotalGames += summonerMatches.TotalGames;
                    }
                }
                else
                {
                    SummonerMatches summonerMatches = await _riotService.GetSummonerMatches(summonerData.AccountId);
                    result.Matches.AddRange(summonerMatches.Matches);
                    result.TotalGames += summonerMatches.TotalGames;
                }
            }
            result.Matches = new List<Match>(result.Matches.OrderByDescending(c => c.Timestamp));
            return result;
        }
    }
}
